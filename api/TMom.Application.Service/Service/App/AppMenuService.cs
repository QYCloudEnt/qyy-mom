using TMom.Application.Service.IService;
using TMom.Domain.Model.Entity;
using TMom.Domain.IRepository;
using SqlSugar;
using TMom.Domain.Model;
using TMom.Infrastructure;
using TMom.Application.Dto;

namespace TMom.Application.Service.Service
{
    public class AppMenuService : BaseService<AppMenu, int>, IAppMenuService
    {
        private readonly IBaseRepository<AppMenu, int> _dal;
        private readonly IAppMenuRepository _appMenuRepository;
        private readonly IUser _user;
        private readonly ISysUserRoleRepository _sysUserRoleRepository;

        public AppMenuService(IBaseRepository<AppMenu, int> dal, IAppMenuRepository appMenuRepository, IUser user
                , ISysUserRoleRepository sysUserRoleRepository)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _appMenuRepository = appMenuRepository;
            _user = user;
            _sysUserRoleRepository = sysUserRoleRepository;
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<AppMenuDto>> GetList()
        {
            var list = await _appMenuRepository.Query();
            var parentList = list.Where(x => !x.ParentId.HasValue).Select(x => new AppMenuDto()
            {
                Id = x.Id,
                Label = x.Name,
                Icon = x.Icon,
                Color = x.IconColor,
            }).ToList();
            foreach (var parent in parentList)
            {
                var children = list.Where(x => x.ParentId == parent.Id).Select(x => new AppMenuItem()
                {
                    Id = x.Id,
                    Label = x.Name,
                    Icon = x.Icon,
                    Color = x.IconColor,
                    FnStr = x.FnStr,
                    SysRoleIds = x.SysRoleIds.IsNotEmptyOrNull() ? x.SysRoleIds.Split(",").Select(t => t.ObjToInt()).ToList() : [],
                }).ToList();
                parent.Items = children;
            }
            List<AppMenuDto> result = parentList.ToList();
            return result;
        }

        /// <summary>
        /// 获取当前用户拥有权限的菜单列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<AppMenuDto>> GetAuthMenus()
        {
            var roleIds = await _sysUserRoleRepository.Query(x => x.SysRoleId, x => x.SysUserId == _user.Id, "");
            List<AppMenuDto> result = await GetList();
            foreach (var parent in result)
            {
                parent.Items = parent.Items.Where(x => x.SysRoleIds.Intersect(roleIds).Any()).ToList();
            }
            List<AppMenuDto> list = result.Where(x => x.Items.Any()).ToList();
            return list;
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public async Task<int> AddData(AppMenuAddParam para)
        {
            AppMenu entity = new AppMenu()
            {
                Name = para.Name,
                ParentId = para.ParentId,
            };
            entity.UpdateCommonFields(_user.Id);
            var id = await _appMenuRepository.Add(entity);
            return id;
        }

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name="ids">多个以逗号分隔</param>
        /// <returns></returns>
        public async Task<bool> DeleteData(string ids)
        {
            List<int> idList = ids.Split(',').Select(id => id.ObjToInt()).ToList();
            bool isSuccess = await _appMenuRepository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            return isSuccess;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        [UseTran]
        public async Task<bool> Save(List<AppMenuDto> para)
        {
            _dal.Db.DbMaintenance.TruncateTable<AppMenu>();
            var dataList = para.Select((item, ind) => new
            {
                parent = new AppMenu()
                {
                    Name = item.Label,
                    ParentId = null,
                    Icon = item.Icon,
                    IconColor = item.Color,
                    SortNo = ind + 1
                },
                children = item.Items.Select((x, n) => new AppMenu()
                {
                    Name = x.Label,
                    Icon = x.Icon,
                    IconColor = x.Color,
                    FnStr = x.FnStr,
                    SysRoleIds = string.Join(",", x.SysRoleIds),
                    SortNo = n + 1
                }).ToList()
            }).ToList();
            var parentList = dataList.Select(x => x.parent).ToList();
            var list = await _appMenuRepository.Add(parentList);

            List<AppMenu> children = new List<AppMenu>();
            foreach (var item in dataList)
            {
                int ind = dataList.IndexOf(item);
                int parentId = list[ind];
                foreach (var child in item.children)
                {
                    child.ParentId = parentId;
                }
                children.AddRange(item.children);
            }
            await _appMenuRepository.Add(children);
            return true;
        }
    }
}
using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;
using TMom.Infrastructure;

namespace TMom.Application.Service.Service
{
    public class SysRoleMenuService : BaseService<SysRoleMenu, int>, ISysRoleMenuService
    {
        private readonly IBaseRepository<SysRoleMenu, int> _dal;

        public SysRoleMenuService(IBaseRepository<SysRoleMenu, int> dal)
        {
            this._dal = dal;
            base.BaseRepo = dal;
        }

        public async Task<List<SysRoleMenu>> RoleMenuMaps()
        {
            return await _dal.Db.Queryable<SysRoleMenu>()
                                .Includes(x => x.SysRole)
                                .Includes(x => x.SysMenu)
                                .Where(x => x.SysRole.IsDeleted == false && x.SysMenu.IsDeleted == false && x.IsDeleted == false)
                                .ToListAsync();
        }

        /// <summary>
        /// 测试事务AOP
        /// </summary>
        /// <returns></returns>
        [UseTran]
        public async Task TestAOP()
        {
            await _dal.Add(new SysRoleMenu()
            {
                SysRoleId = 0,
                SysMenuId = 0
            });

            //var model = await _dal_order.Db.Queryable<SysOrder>().Where(x => x.Id == 1).FirstAsync();

            var s = 0;
            var ss = 1 / s;

            // 跨库
            //model.Code = "test";
            //await _dal_order.Db.Updateable(model).ExecuteCommandHasChangeAsync();

            // 同库
            //var entity = await _dal.QueryById(1);
            //entity.UpdateTime = DateTime.Now;
            //await _dal.Update(entity);
        }
    }
}
using System.Linq.Expressions;
using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;
using TMom.Infrastructure;

namespace TMom.Application.Service.Service
{
    public class SkillService : BaseService<Skill, int>, ISkillService
    {
        private readonly IBaseRepository<Skill, int> _dal;
        private readonly IBaseRepository<SkillAndUser, int> _skillAndUserRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IUser _user;

        public SkillService(IBaseRepository<Skill, int> dal, ISkillRepository skillRepository, IUser user
            , IBaseRepository<SkillAndUser, int> skillAndUserRepository)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _skillRepository = skillRepository;
            _user = user;
            _skillAndUserRepository = skillAndUserRepository;
        }

        #region 模板生成 CRUD

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="whereExp">查询条件表达式 Item1: 主表查询条件表达式, Item2: 导航表查询条件集合</param>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <param name="orderByFields">排序字段, 如name asc,age desc</param>
        /// <returns></returns>
        public async Task<PageModel<Skill>> GetWithPage((Expression<Func<Skill, bool>>, List<FormattableString>) whereExp
            , int pageIndex, int pageSize, string orderByFields = "")
        {
            var data = await _skillRepository.QueryPage(whereExp.Item1, pageIndex, pageSize, null, orderByFields);
            return data;
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Skill> GetById(int id)
        {
            var entity = await _skillRepository.QueryById(id);
            return entity;
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddData(Skill entity)
        {
            entity.UpdateCommonFields(_user.Id);
            var id = await _skillRepository.Add(entity);
            return id;
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改的主键Id</returns>
        public async Task<bool> UpdateData(Skill entity)
        {
            entity.UpdateCommonFields(_user.Id, false);
            bool isSuccess = await _skillRepository.Update(entity);
            return isSuccess;
        }

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name="ids">多个以逗号分隔</param>
        /// <returns></returns>
        public async Task<bool> DeleteData(string ids)
        {
            List<int> idList = ids.Split(',').Select(id => id.ObjToInt()).ToList();
            bool isSuccess = await _skillRepository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            return isSuccess;
        }

        #endregion 模板生成 CRUD

        /// <summary>
        /// 分配技能给用户
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="sysUserIds">用户id集合</param>
        /// <returns></returns>
        [UseTran]
        public async Task<bool> AssignSkillToUser(int skillId, List<int> sysUserIds)
        {
            var dataList = await _skillAndUserRepository.Query(x => x.SkillId == skillId);
            var allUserIds = dataList.Select(x => x.SysUserId).ToList();
            var addUserIds = sysUserIds.Except(allUserIds);
            var delUserIds = allUserIds.Except(sysUserIds);
            var addList = addUserIds.Select(userId => new SkillAndUser() { SkillId = skillId, SysUserId = userId }).ToList();
            addList.UpdateCommonFields(_user.Id);
            var delList = dataList.Where(x => delUserIds.Contains(x.SysUserId)).ToList();
            delList.MarkedAsDeleted(_user.Id);
            await _skillAndUserRepository.Add(addList);
            await _skillAndUserRepository.Update(delList);
            return true;
        }

        /// <summary>
        /// 获取分配技能的用户Id集合
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <returns></returns>
        public async Task<List<int>> GetAssignUserIdBySkillId(int skillId)
        {
            var sysUserIds = await _skillAndUserRepository.Query(x => x.SysUserId, x => x.SkillId == skillId, "");
            return sysUserIds;
        }
    }
}
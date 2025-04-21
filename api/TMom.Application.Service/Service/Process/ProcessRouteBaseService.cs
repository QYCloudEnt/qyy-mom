using System.Linq.Expressions;
using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;
using TMom.Infrastructure;

namespace TMom.Application.Service.Service
{
    public class ProcessRouteBaseService : BaseService<ProcessRouteBase, int>, IProcessRouteBaseService
    {
        private readonly IBaseRepository<ProcessRouteBase, int> _dal;
        private readonly IProcessRouteBaseRepository _processRouteBaseRepository;
        private readonly IUser _user;

        public ProcessRouteBaseService(IBaseRepository<ProcessRouteBase, int> dal, IProcessRouteBaseRepository processRouteBaseRepository, IUser user)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _processRouteBaseRepository = processRouteBaseRepository;
            _user = user;
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
        public async Task<PageModel<ProcessRouteBase>> GetWithPage((Expression<Func<ProcessRouteBase, bool>>, List<FormattableString>) whereExp, int pageIndex, int pageSize, string orderByFields = "")
        {
            var data = await _processRouteBaseRepository.QueryPage(whereExp.Item1, pageIndex, pageSize, null, orderByFields);
            return data;
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProcessRouteBase> GetById(int id)
        {
            var entity = await _processRouteBaseRepository.QueryById(id);
            return entity;
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddData(ProcessRouteBase entity)
        {
            entity.UpdateCommonFields(_user.Id);
            var id = await _processRouteBaseRepository.Add(entity);
            return id;
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改的主键Id</returns>
        public async Task<bool> UpdateData(ProcessRouteBase entity)
        {
            entity.UpdateCommonFields(_user.Id, false);
            bool isSuccess = await _processRouteBaseRepository.Update(entity);
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
            bool isSuccess = await _processRouteBaseRepository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            return isSuccess;
        }

        #endregion 模板生成 CRUD
    }
}
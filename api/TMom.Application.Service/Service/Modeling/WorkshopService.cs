using System.Linq.Expressions;
using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;

namespace TMom.Application.Service.Service
{
    public class WorkshopService : BaseService<Workshop, int>, IWorkshopService
    {
        private readonly IBaseRepository<Workshop, int> _dal;
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IUser _user;

        public WorkshopService(IBaseRepository<Workshop, int> dal, IWorkshopRepository workshopRepository, IUser user)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _workshopRepository = workshopRepository;
            _user = user;
        }

        #region 模板生成 CRUD

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="whereExp">查询条件表达式 Item1: 主表查询条件表达式, Item2: 导航表查询条件集合</param>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <returns></returns>
        public async Task<PageModel<Workshop>> GetWithPage((Expression<Func<Workshop, bool>>, List<FormattableString>) whereExp, int pageIndex, int pageSize)
        {
            var data = await _workshopRepository.QueryPage(whereExp.Item1, pageIndex, pageSize);
            return data;
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Workshop> GetById(int id)
        {
            var entity = await _workshopRepository.QueryById(id);
            return entity;
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddData(Workshop entity)
        {
            entity.UpdateCommonFields(_user.Id);
            var id = await _workshopRepository.Add(entity);
            return id;
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改的主键Id</returns>
        public async Task<bool> UpdateData(Workshop entity)
        {
            entity.UpdateCommonFields(_user.Id, false);
            bool isSuccess = await _workshopRepository.Update(entity);
            return isSuccess;
        }

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name="ids">多个以逗号分隔</param>
        /// <returns></returns>
        public async Task<bool> DeleteData(string ids)
        {
            List<int> idList = ids.Split(',').Select(id => int.Parse(id)).ToList();
            bool isSuccess = await _workshopRepository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            return isSuccess;
        }

        #endregion 模板生成 CRUD
    }
}
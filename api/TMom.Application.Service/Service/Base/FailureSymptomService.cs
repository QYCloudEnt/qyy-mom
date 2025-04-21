using System.Linq.Expressions;
using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;
using TMom.Infrastructure;
using TMom.Application.Dto;
using TMom.Infrastructure.Helper;

namespace TMom.Application.Service.Service
{
    public class FailureSymptomService : BaseService<FailureSymptom, int>, IFailureSymptomService
    {
        private readonly IBaseRepository<FailureSymptom, int> _dal;
        private readonly IFailureSymptomRepository _failureSymptomRepository;
        private readonly IUser _user;

        public FailureSymptomService(IBaseRepository<FailureSymptom, int> dal, IFailureSymptomRepository failureSymptomRepository, IUser user)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _failureSymptomRepository = failureSymptomRepository;
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
        public async Task<PageModel<FailureSymptom>> GetWithPage((Expression<Func<FailureSymptom, bool>>, List<FormattableString>) whereExp
            , int pageIndex, int pageSize, string orderByFields = "")
        {
            var data = await _failureSymptomRepository.QueryIncludesPage(whereExp.Item1, pageIndex, pageSize, null, orderByFields, whereExp.Item2, x => x.FailureType);
            return data;
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FailureSymptom> GetById(int id)
        {
            var entity = await _failureSymptomRepository.QueryById(id);
            return entity;
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddData(FailureSymptom entity)
        {
            entity.UpdateCommonFields(_user.Id);
            var id = await _failureSymptomRepository.Add(entity);
            return id;
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改的主键Id</returns>
        public async Task<bool> UpdateData(FailureSymptom entity)
        {
            entity.UpdateCommonFields(_user.Id, false);
            bool isSuccess = await _failureSymptomRepository.Update(entity);
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
            bool isSuccess = await _failureSymptomRepository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            return isSuccess;
        }

        #endregion 模板生成 CRUD

        /// <summary>
        /// 获取不良现象Options
        /// </summary>
        /// <param name="typeId">不良类型Id</param>
        /// <returns></returns>
        public async Task<List<SelectDto>> GetFailureSymptomOptions(int? typeId)
        {
            Expression<Func<FailureSymptom, bool>> whereExp = x => true;
            whereExp = whereExp.AndIF(typeId.HasValue, x => x.FailureTypeId == typeId.Value);
            var list = await _failureSymptomRepository.Query(x => new { x.Id, x.Name }, whereExp, "");
            List<SelectDto> dataList = list.Select(x => new SelectDto
            {
                label = x.Name,
                value = x.Id,
            }).ToList();
            return dataList;
        }
    }
}
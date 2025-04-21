using System.Linq.Expressions;
using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;
using TMom.Infrastructure;
using TMom.Application.Dto;

namespace TMom.Application.Service.Service
{
    public class BomService : BaseService<Bom, int>, IBomService
    {
        private readonly IBaseRepository<Bom, int> _dal;
        private readonly IBomRepository _bomRepository;
        private readonly IUser _user;
        private readonly IPartMaterialRepository _partMaterialRepository;

        public BomService(IBaseRepository<Bom, int> dal, IBomRepository bomRepository, IUser user, IPartMaterialRepository partMaterialRepository)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _bomRepository = bomRepository;
            _user = user;
            _partMaterialRepository = partMaterialRepository;
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
        public async Task<PageModel<Bom>> GetWithPage((Expression<Func<Bom, bool>>, List<FormattableString>) whereExp, int pageIndex, int pageSize, string orderByFields = "")
        {
            var data = await _bomRepository.QueryPage(whereExp.Item1, pageIndex, pageSize, null, orderByFields);
            return data;
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Bom> GetById(int id)
        {
            var entity = await _bomRepository.QueryById(id);
            return entity;
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddData(Bom entity)
        {
            entity.UpdateCommonFields(_user.Id);
            await UpdateBomLevel(entity);
            var id = await _bomRepository.Add(entity);
            return id;
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改的主键Id</returns>
        public async Task<bool> UpdateData(Bom entity)
        {
            entity.UpdateCommonFields(_user.Id, false);
            await UpdateBomLevel(entity);
            bool isSuccess = await _bomRepository.Update(entity);
            return isSuccess;
        }

        /// <summary>
        /// 更新Bom阶别
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="CustomFailRequestException"></exception>
        private async Task UpdateBomLevel(Bom entity)
        {
            if (string.IsNullOrWhiteSpace(entity.ParentCode))
            {
                entity.Level = 0;
            }
            else
            {
                var parent = await _bomRepository.QuerySingle(x => x.Code == entity.ParentCode);
                if (parent == null) throw new CustomFailRequestException($"Bom编码: {entity.Code}的父元素: {entity.ParentCode}不存在, 请检查!");
                entity.Level = parent.Level + 1;
            }
        }

        /// <summary>
        /// 根据主键Id删除数据
        /// </summary>
        /// <param name="ids">多个以逗号分隔</param>
        /// <returns></returns>
        public async Task<bool> DeleteData(string ids)
        {
            List<int> idList = ids.Split(',').Select(id => id.ObjToInt()).ToList();
            bool isSuccess = await _bomRepository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            return isSuccess;
        }

        #endregion 模板生成 CRUD

        /// <summary>
        /// Bom和产品料号绑定(默认情况下两者Code一致关联)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> BindPart(BomBindPartParam model)
        {
            bool res = await _bomRepository.Update(x => x.Id == model.Id, x => new Bom()
            {
                PartCode = model.PartCode,
                UpdateId = _user.Id,
                UpdateTime = DateTime.Now
            });
            return res;
        }

        /// <summary>
        /// 获取所有Bom集合
        /// </summary>
        /// <param name="whereExp"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<Bom>> GetList((Expression<Func<Bom, bool>>, List<FormattableString>) whereExp)
        {
            var list = await _bomRepository.QueryIncludes(x => x.ProcessOperation, whereExp.Item1);
            return list;
        }
    }
}
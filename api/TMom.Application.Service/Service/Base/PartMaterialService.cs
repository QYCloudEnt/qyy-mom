using System.Linq.Expressions;
using TMom.Application.Service.IService;
using TMom.Domain.IRepository;
using TMom.Domain.Model.Entity;
using TMom.Domain.Model;
using TMom.Infrastructure;

namespace TMom.Application.Service.Service
{
    public class PartMaterialService : BaseService<PartMaterial, int>, IPartMaterialService
    {
        private readonly IBaseRepository<PartMaterial, int> _dal;
        private readonly IPartMaterialRepository _partRepository;
        private readonly IUser _user;
        private readonly IBomRepository _bomRepository;

        public PartMaterialService(IBaseRepository<PartMaterial, int> dal, IPartMaterialRepository partRepository, IUser user, IBomRepository bomRepository)
        {
            this._dal = dal;
            base.BaseRepo = dal;
            _partRepository = partRepository;
            _user = user;
            _bomRepository = bomRepository;
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
        public async Task<PageModel<PartMaterial>> GetWithPage((Expression<Func<PartMaterial, bool>>, List<FormattableString>) whereExp, int pageIndex, int pageSize, string orderByFields = "")
        {
            var data = await _partRepository.QueryIncludesPage(whereExp.Item1, pageIndex, pageSize, null, orderByFields
                        , whereExp.Item2, x => x.PartGroup);
            return data;
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PartMaterial> GetById(int id)
        {
            var entity = (await _partRepository.QueryIncludes(x => x.PartGroup, x => x.Id == id)).FirstOrDefault();
            return entity;
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddData(PartMaterial entity)
        {
            entity.UpdateCommonFields(_user.Id);
            var id = await _partRepository.Add(entity);
            return id;
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>修改的主键Id</returns>
        public async Task<bool> UpdateData(PartMaterial entity)
        {
            entity.UpdateCommonFields(_user.Id, false);
            bool isSuccess = await _partRepository.Update(entity);
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
            bool isSuccess = await _partRepository.DeleteSoft(x => idList.Contains(x.Id), _user.Id);
            return isSuccess;
        }

        #endregion 模板生成 CRUD

        /// <summary>
        /// 获取产品对应的BOM编码
        /// </summary>
        /// <param name="id">产品料号id</param>
        /// <returns></returns>
        public async Task<string> GetBomCode(int id)
        {
            var part = await _partRepository.QuerySingle(x => x.Id == id);
            if (part == null) throw new CustomFailRequestException($"产品id:{id}不存在!");
            string code = await _dal.Db.Queryable<Bom>().Where(x => x.PartCode == part.Code && x.Level == 0 && !x.IsDeleted)
                                                        .Select(x => x.Code).FirstAsync();
            if (!string.IsNullOrEmpty(code)) return code;
            bool hasBom = await _dal.Db.Queryable<Bom>().AnyAsync(x => x.Code == part.Code && x.Level == 0 && !x.IsDeleted);
            if (!hasBom) throw new CustomFailRequestException($"产品:{part.Code}对应的BOM不存在!");
            return part.Code;
        }

        /// <summary>
        /// 获取产品BOM清单
        /// </summary>
        /// <param name="id">产品id</param>
        /// <returns></returns>
        public async Task<List<Bom>> GetBom(int id)
        {
            string bomCode = await GetBomCode(id);
            var list = await _bomRepository.QueryIncludes(x => x.ProcessOperation, x => x.ParentCode == bomCode);
            return list;
        }

        /// <summary>
        /// 根据群组类型获取产品料号
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<List<PartMaterial>> GetListByGroupType(PartGroupType type)
        {
            var list = await _partRepository.QueryIncludes(x => x.PartGroup, x => x.PartGroup.Type == type);
            return list;
        }
    }
}
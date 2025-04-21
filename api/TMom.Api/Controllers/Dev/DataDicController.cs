using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TMom.Domain.Model.Entity;
using TMom.Application.Service.IService;
using static TMom.Domain.Model.GlobalVars;
using TMom.Application;
using TMom.Domain.Model;
using SqlSugar;
using System.Data;
using System.Linq.Expressions;
using TMom.Infrastructure.Helper;

namespace TMom.Api.Controllers
{
    /// <summary>
    /// 数据字典
    /// </summary>
	[Route("api/[controller]/[action]")]
    [ApiController]
    public class DataDicController : BaseApiController<DataDic, int>
    {
        /// <summary>
        /// 模板生成
        /// </summary>
        private readonly IDataDicService _baseDataDicService;

        private readonly IUser _user;
        private readonly IMapper _mapper;
        private readonly IRedisRepository _redis;
        private readonly ISqlSugarClient _sqlSugarClient;

        public DataDicController(IDataDicService BaseDataDicService, IUser user, IMapper mapper, IRedisRepository redis, ISqlSugarClient sqlSugarClient)
        {
            _baseDataDicService = BaseDataDicService;
            _user = user;
            _mapper = mapper;
            _redis = redis;
            _sqlSugarClient = sqlSugarClient;
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="categoryCode"></param>
        /// <param name="pageIndex">页标, 默认1</param>
        /// <param name="pageSize">页数, 默认10</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<PageModel<DataDic>>> GetWithPage(string code, string name, string? categoryCode
                , int pageIndex = 1, int pageSize = 10)
        {
            var whereExpression = Expressionable.Create<DataDic>()
                                                .AndIF(code.IsNotEmptyOrNull(), x => x.Code.Contains(code))
                                                .AndIF(name.IsNotEmptyOrNull(), x => x.Name.Contains(name))
                                                .AndIF(categoryCode.IsNotEmptyOrNull(), x => x.CategoryCode == categoryCode)
                                                .ToExpression();

            var data = await _baseDataDicService.QueryPage(whereExpression, pageIndex, pageSize);
            data.list = data.list.OrderBy(x => x.SortNo).ToList();
            return new MessageModel<PageModel<DataDic>>()
            {
                msg = "获取成功",
                success = true,
                data = data
            };
        }

        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <param name="key">分类编码或名称</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<DataDic>>> GetCateoryList(string? key)
        {
            Expression<Func<DataDic, bool>> exp = a => (a.CategoryCode == "#" || a.CategoryCode == "BaseCategory");
            exp = exp.AndIF(key.IsNotEmptyOrNull(), x => x.Name.Contains(key));
            var list = await _baseDataDicService.Query(exp, "SortNo");
            return Success(list);
        }

        /// <summary>
        /// 根据主键Id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<MessageModel<DataDic>> Get(int id)
        {
            var entity = await _baseDataDicService.QueryById(id);
            if (entity == null || entity.Id <= 0)
            {
                return Failed<DataDic>($"主键:{id}不存在或已被删除!");
            }
            return new MessageModel<DataDic>()
            {
                msg = "获取成功",
                success = true,
                data = entity
            };
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> Add([FromBody] DataDic request)
        {
            var res = new MessageModel<string>();
            bool isExist = (await _baseDataDicService.Query(x => x.CategoryCode == request.CategoryCode
                            && (x.Code == request.Code || x.Name == request.Name)))
                            .Any();
            if (isExist) return Failed($"分类: {request.CategoryName}已存在相同的编码或名称: {request.Code}、{request.Name}");

            request.UpdateCommonFields(_user.Id);
            var Id = await _baseDataDicService.Add(request);
            if (Id > 0)
            {
                res.success = true;
                res.data = Id.ObjToString();
                res.msg = "添加成功";
            }

            return res;
        }

        /// <summary>
        /// 修改全部数据(默认根据主键更新)
        /// </summary>
        /// <param name="request"></param>
        /// <returns>修改的主键Id</returns>
        [HttpPut]
        public async Task<MessageModel<string>> Update([FromBody] DataDic request)
        {
            var res = new MessageModel<string>();
            bool isExist = await _baseDataDicService.Any(x => x.Id != request.Id && x.CategoryCode == request.CategoryCode && x.Code == request.Code);
            if (isExist) return Failed($"分类: {request.CategoryName}已存在相同的编码: {request.Code}");
            request.UpdateCommonFields(_user.Id, false);
            bool success = await _baseDataDicService.Update(request);
            if (success)
            {
                if (request.CategoryCode == "BaseCategory")
                {
                    await _baseDataDicService.Update(x => x.CategoryCode == request.Code, x => new DataDic() { CategoryName = request.Name });
                }
                return Success<string>(request.Id.ToString(), "更新成功!");
            }
            return Failed();
        }

        /// <summary>
        /// 根据主键Id删除一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<MessageModel<string>> Delete(int id)
        {
            var entity = await _baseDataDicService.QueryById(id);
            if (entity == null || entity.Id <= 0)
            {
                return Failed($"主键:{id}不存在或已被删除!");
            }
            entity.MarkedAsDeleted(_user.Id);
            bool success = await _baseDataDicService.Update(entity);
            // 如果删除的是基础分类, 把子数据也要全部删除
            var childList = await _baseDataDicService.Query(x => x.CategoryName == entity.Name);
            if (childList != null && childList.Any())
            {
                childList.ForEach(item => item.MarkedAsDeleted(_user.Id));
                await _baseDataDicService.Update(childList);
            }
            return success ? Success<string>(id.ObjToString(), "删除成功!") : Failed();
        }
    }
}
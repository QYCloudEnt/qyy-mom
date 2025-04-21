using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using TMom.Application;
using TMom.Application.Dto;
using TMom.Domain.Model;
using Newtonsoft.Json;
using SqlSugar;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace TMom.Api.Controllers
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    public class BaseApiController<TEntity, TKey> : ControllerBase where TEntity : RootEntity<TKey>, new() where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 动态组装分页的过滤条件表达式树
        /// <para>只处理常用的Input、Select等</para>
        /// <para>注意: 日期类型 或者 不在表中的字段参数 不处理, 需要在具体方法中自定义处理</para>
        /// </summary>
        /// <returns>Item1: 主表查询条件表达式, Item2: 导航表查询条件集合</returns>
        [NonAction]
        public (Expression<Func<TEntity, bool>>, List<FormattableString>) DynamicFilterExpress()
        {
            // 主表查询条件
            var whereExpression = Expressionable.Create<TEntity>();
            whereExpression.And(x => x.IsDeleted == false);
            // 导航表查询条件
            List<FormattableString> includeWhereExpList = new List<FormattableString>();

            var header = HttpContext?.Request?.Headers;
            var query = HttpContext?.Request?.Query;
            if (header == null) return (whereExpression.ToExpression(), includeWhereExpList);
            header.TryGetValue("HeaderUniqForm", out var formValue);
            if (string.IsNullOrEmpty(formValue) || query == null) return (whereExpression.ToExpression(), includeWhereExpList);
            FormFilterDto formFilterDto = new FormFilterDto();
            try
            {
                formFilterDto = JsonConvert.DeserializeObject<FormFilterDto>(formValue) ?? new FormFilterDto();
            }
            catch
            {
                return (whereExpression.ToExpression(), includeWhereExpList);
            }

            foreach (string key in query.Keys)
            {
                string field = key;
                query.TryGetValue(field, out var value);
                if (field.Contains("["))
                {
                    field = string.Join(".", field.Split("[").Select(x => x.TrimEnd(']')));
                }
                string component = formFilterDto.form.Where(x => x.field == field).Select(x => x.type).FirstOrDefault() ?? "";
                // 暂时不处理日期类型组件
                if (string.IsNullOrEmpty(component) || component.Contains("Picker") || string.IsNullOrEmpty(value)) continue;

                RenderWhereExp(whereExpression, includeWhereExpList, component, field, value);
            }
            query.TryGetValue("createTimeS", out var createTimeS);
            query.TryGetValue("createTimeE", out var createTimeE);
            whereExpression.AndIF(createTimeS.IsNotEmptyOrNull(), x => x.CreateTime >= DateTime.Parse(createTimeS.ObjToString()));
            whereExpression.AndIF(createTimeE.IsNotEmptyOrNull(), x => x.CreateTime < DateTime.Parse(createTimeE.ObjToString()).AddDays(1));
            return (whereExpression.ToExpression(), includeWhereExpList);
        }

        /// <summary>
        /// 处理查询条件
        /// </summary>
        [NonAction]
        private void RenderWhereExp(Expressionable<TEntity> whereExpression
            , List<FormattableString> includeWhereExpList, string component, string field, StringValues value)
        {
            if (component.StartsWith("Tree") || component.ToLower().EndsWith("select"))
            {
                if (value.ToString() == "true" || value.ToString() == "false")
                {
                    RenderBoolCol(whereExpression, includeWhereExpList, field, value);
                }
                else if (value.ToString().Contains(","))
                {
                    RenderInCol(whereExpression, includeWhereExpList, field, value);
                }
                else
                {
                    RenderEqualsCol(whereExpression, includeWhereExpList, field, value);
                }
            }
            else if (field == "createUser")
            {
                whereExpression.And(x => x.CreateUserTable.LoginAccount.Contains(value.ObjToString()) || x.CreateUserTable.RealName.Contains(value.ObjToString()));
            }
            else
            {
                RenderLikeCol(whereExpression, includeWhereExpList, field, value);
            }
        }

        #region 处理列字段

        /// <summary>
        /// 模糊查询列 e.g: x.Name like '%admin%'
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="includeWhereExpList"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        [NonAction]
        private void RenderLikeCol(Expressionable<TEntity> whereExpression, List<FormattableString> includeWhereExpList, string field, StringValues value)
        {
            if (field.Contains("."))
            {
                FormattableString formattableString = FormattableStringFactory.Create("x=>x." + field + ".Contains({0})", value.ObjToString());
                includeWhereExpList.Add(formattableString);
            }
            else
            {
                whereExpression.And(x => SqlFunc.MappingColumn<string>(field).Contains(value.ObjToString()));
            }
        }

        /// <summary>
        /// 精确Equals查询列 e.g: x.Name == 'admin'
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="includeWhereExpList"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        [NonAction]
        private void RenderEqualsCol(Expressionable<TEntity> whereExpression, List<FormattableString> includeWhereExpList, string field, StringValues value)
        {
            if (field.Contains("."))
            {
                FormattableString formattableString = FormattableStringFactory.Create("x=>x." + field + "={0}", value.ObjToString());
                includeWhereExpList.Add(formattableString);
            }
            else
            {
                whereExpression.And(x => SqlFunc.Equals(SqlFunc.MappingColumn<string>(field), value.ObjToString()));
            }
        }

        /// <summary>
        /// 多个In查询列 e.g: x.Name In ('admin','test')
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="includeWhereExpList"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        [NonAction]
        private void RenderInCol(Expressionable<TEntity> whereExpression, List<FormattableString> includeWhereExpList, string field, StringValues value)
        {
            List<string> valueList = value.ToString().Split(',').ToList();
            if (field.Contains("."))
            {
                FormattableString formattableString = FormattableStringFactory.Create("x=>{0}.Contains(x." + field + ")", valueList);
                includeWhereExpList.Add(formattableString);
            }
            else
            {
                whereExpression.And(x => SqlFunc.ContainsArray(valueList, SqlFunc.MappingColumn<string>(field)));
            }
        }

        /// <summary>
        /// Bool查询列 e.g: x.IsDeleted = true
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="includeWhereExpList"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        [NonAction]
        private void RenderBoolCol(Expressionable<TEntity> whereExpression, List<FormattableString> includeWhereExpList, string field, StringValues value)
        {
            if (field.Contains("."))
            {
                FormattableString formattableString = FormattableStringFactory.Create("x=>x." + field + "={0}", value.ObjToBool());
                includeWhereExpList.Add(formattableString);
            }
            else
            {
                whereExpression.And(x => SqlFunc.MappingColumn<bool>(field) == value.ObjToBool());
            }
        }

        #endregion 处理列字段

        /// <summary>
        /// 格式化排序字段
        /// </summary>
        /// <param name="field">字段</param>
        /// <param name="orderType">排序规则, ascend | descend</param>
        /// <returns></returns>
        [NonAction]
        public string FormatOrderField(string field, string orderType)
        {
            if (string.IsNullOrWhiteSpace(field)) return "";
            orderType = orderType.ToLower() == "descend" ? "desc" : "asc";
            string orderByFields = $"{field} {orderType}".Trim();
            return orderByFields;
        }

        #region 响应结果

        /// <summary>
        /// 返回成功的结果提示
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="data">返回的数据</param>
        /// <param name="msg">成功消息</param>
        /// <returns>{success = true, msg = msg, data = data}</returns>
        [NonAction]
        public MessageModel<T> Success<T>(T data, string msg = "成功")
        {
            return new MessageModel<T>()
            {
                success = true,
                msg = msg,
                data = data,
            };
        }

        /// <summary>
        /// 返回成功的消息提示
        /// </summary>
        /// <param name="msg">成功消息</param>
        /// <returns>{success = true, msg = msg, data = null}</returns>
        [NonAction]
        public MessageModel<string> Success(string msg = "成功")
        {
            return new MessageModel<string>()
            {
                success = true,
                msg = msg,
                data = null,
            };
        }

        /// <summary>
        /// 返回失败的消息提示
        /// </summary>
        /// <param name="msg">失败消息</param>
        /// <param name="status">状态: 500</param>
        /// <returns></returns>
        [NonAction]
        public MessageModel<string> Failed(string msg = "失败", int status = 500)
        {
            return new MessageModel<string>()
            {
                success = false,
                status = status,
                msg = msg,
                data = null,
            };
        }

        /// <summary>
        /// 返回失败的结果提示
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="msg">失败消息</param>
        /// <param name="status">状态: 500</param>
        /// <returns></returns>
        [NonAction]
        public MessageModel<T> Failed<T>(string msg = "失败", int status = 500)
        {
            return new MessageModel<T>()
            {
                success = false,
                status = status,
                msg = msg,
                data = default,
            };
        }

        /// <summary>
        /// 返回成功的分页结果
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="pageIndex">页下标</param>
        /// <param name="dataCount">每页数量</param>
        /// <param name="data">数据</param>
        /// <param name="pageCount">总共的页数</param>
        /// <param name="msg">成功消息</param>
        /// <returns></returns>
        [NonAction]
        public MessageModel<PageModel<T>> SuccessPage<T>(int pageIndex, int dataCount, List<T> data, int pageCount, string msg = "获取成功")
        {
            return new MessageModel<PageModel<T>>()
            {
                success = true,
                msg = msg,
                data = new PageModel<T>()
                {
                    list = data,
                    pagination = new pageInfo()
                    {
                        pageIndex = pageIndex,
                        total = dataCount,
                        pageSize = pageCount
                    }
                }
            };
        }

        /// <summary>
        /// 返回成功的分页结果
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="pageModel">通用的分页信息类</param>
        /// <param name="msg">成功消息</param>
        /// <returns></returns>
        [NonAction]
        public MessageModel<PageModel<T>> SuccessPage<T>(PageModel<T> pageModel, string msg = "获取成功")
        {
            return new MessageModel<PageModel<T>>()
            {
                success = true,
                msg = msg,
                data = new PageModel<T>()
                {
                    list = pageModel.list,
                    pagination = pageModel.pagination
                }
            };
        }

        #endregion 响应结果
    }
}
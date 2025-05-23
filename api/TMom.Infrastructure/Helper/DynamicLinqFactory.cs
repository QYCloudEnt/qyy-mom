﻿using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace TMom.Infrastructure.Helper
{
    #region 动态linq帮助类，连接符号，运算符号

    /// <summary>
    /// 动态linq工厂
    /// </summary>
    public static class DynamicLinqFactory
    {
        /// <summary>
        /// 生成lambd表达式(如:CompanyID != 1 & CompanyID == 1)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="propertyStr"></param>
        /// <returns></returns>
        public static Expression<Func<TSource, bool>> CreateLambda<TSource>(string propertyStr)
        {
            // 设置自定义lanbd
            // 定义 lanbd 种子（p=> xxxxxx）中的 p
            if (string.IsNullOrWhiteSpace(propertyStr))
                return LinqHelper.True<TSource>();//为空就返回空的表达式

            var parameter = Expression.Parameter(typeof(TSource), "p");
            var strArr = SpiltStrings(propertyStr);

            // 第一个判断条件，固定一个判断条件作为最左边
            Expression mainExpressin = ExpressionStudio(null, strArr.FirstOrDefault(x => x.LinkSymbol == LinkSymbol.Empty), parameter);

            // 将需要放置在最左边的判断条件从列表中去除，因为已经合成到表达式最左边了
            strArr.Remove(strArr.FirstOrDefault(x => x.LinkSymbol == LinkSymbol.Empty));

            foreach (var x in strArr)
            {
                mainExpressin = ExpressionStudio(mainExpressin, x, parameter);
            }

            return mainExpressin.ToLambda<Func<TSource, bool>>(parameter);
        }

        /// <summary>
        /// 组合条件判断表达式
        /// </summary>
        /// <param name="left">左边的表达式</param>
        /// <param name="DynamicLinq"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Expression ExpressionStudio(Expression left, DynamicLinqHelper DynamicLinq, ParameterExpression key)
        {
            Expression mainExpression = key;

            var properties = DynamicLinq.Left.Split('.');

            // 从1开始，是不想用自定义种子，外层种子已经定义好了
            // 暂时也不会有多个自定义种子，先这样
            for (var i = 0; i < properties.Length; i++)
            {
                mainExpression = mainExpression.Property(properties[i]);
            }

            left = left == null
            // 如果左边表达式为空，则当前的表达式就为最左边
            ? ChangeOperationSymbol(DynamicLinq.OperationSymbol, mainExpression, DynamicLinq.Right)
            // 如果不为空，则将当前的表达式连接到左边
            : ChangeLinkSymbol(DynamicLinq.LinkSymbol, left, ChangeOperationSymbol(DynamicLinq.OperationSymbol, mainExpression, DynamicLinq.Right));
            return left;
        }

        /// <summary>
        /// 将字符串装换成动态帮助类（内含递归）
        /// </summary>
        public static List<DynamicLinqHelper> SpiltStrings(string propertyStr)
        {
            // 定义返回用List
            var outList = new List<DynamicLinqHelper>();

            // 当最后已经没有连接运算符的时候，进入该条件
            if (!propertyStr.Contains("&") & !propertyStr.Contains("|"))
            {
                // 当前的条件是不具备连接符号的
                var lastStr = propertyStr.Trim().Split(' ');
                outList.Add(new DynamicLinqHelper
                {
                    LinkSymbol = LinkSymbol.Empty,
                    Left = lastStr[0],
                    Right = lastStr[2],
                    OperationSymbol = ChangeOperationSymbol(lastStr[1])
                });
                return outList;
            }
            // 判断当前 & | 哪个符号在最后一个判断逻辑内
            var key = propertyStr.LastIndexOf('&') > propertyStr.LastIndexOf('|') ? '&' : '|';

            var nowStrArr = propertyStr.Substring(propertyStr.LastIndexOf(key)).Trim().Split(' ');

            outList.Add(new DynamicLinqHelper
            {
                LinkSymbol = ChangeLinkSymbol(nowStrArr[0]),
                Left = nowStrArr[1],
                OperationSymbol = ChangeOperationSymbol(nowStrArr[2]),
                Right = nowStrArr[3]
            });
            // 将剩余部分继续切割
            propertyStr = propertyStr.Substring(0, propertyStr.LastIndexOf(key)).Trim();
            // 递归 由后彺前
            outList.AddRange(SpiltStrings(propertyStr));

            return outList;
        }

        /// <summary>
        /// 将字符串符号转成运算枚举符号
        /// </summary>
        public static LinkSymbol ChangeLinkSymbol(string str)
        {
            // 这里判断链接符号
            // 当链接符号为Empty，则说明当前对象为表达式的最左边
            // 如果一个表达式出现两次链接符号为空，则说明输入的字符串格式有问题
            switch (str)
            {
                case "|":
                    return LinkSymbol.OrElse;

                case "&":
                    return LinkSymbol.AndAlso;

                default:
                    return LinkSymbol.Empty;
            }
        }

        /// <summary>
        /// 将运算枚举符号转成具体使用方法
        /// </summary>
        public static Expression ChangeLinkSymbol(LinkSymbol Symbol, Expression left, Expression right)
        {
            switch (Symbol)
            {
                case LinkSymbol.OrElse:
                    return left.OrElse(right);

                case LinkSymbol.AndAlso:
                    return left.AndAlso(right);

                default:
                    return left;
            }
        }

        /// <summary>
        /// 将字符串符号转成运算枚举符号
        /// </summary>
        public static OperationSymbol ChangeOperationSymbol(string str)
        {
            switch (str)
            {
                case "<":
                    return OperationSymbol.LessThan;

                case "<=":
                    return OperationSymbol.LessThanOrEqual;

                case ">":
                    return OperationSymbol.GreaterThan;

                case ">=":
                    return OperationSymbol.GreaterThanOrEqual;

                case "==":
                case "=":
                    return OperationSymbol.Equal;

                case "!=":
                    return OperationSymbol.NotEqual;

                case "contains":
                case "like":
                    return OperationSymbol.Contains;
            }
            throw new Exception("OperationSymbol IS NULL");
        }

        /// <summary>
        /// 将运算枚举符号转成具体使用方法
        /// </summary>
        public static Expression ChangeOperationSymbol(OperationSymbol symbol, Expression key, object right)
        {
            // 将右边数据类型强行转换成左边一样的类型
            // 两者如果Type不匹配则无法接下去的运算操作，抛出异常
            object newTypeRight;
            if (right == null || string.IsNullOrEmpty(right.ToString()) || right.ToString() == "null")
                newTypeRight = null;
            else
                newTypeRight = Convert.ChangeType(right, key.Type);

            // 根据当前枚举类别判断使用那种比较方法
            switch (symbol)
            {
                case OperationSymbol.Equal:
                    return key.Equal(Expression.Constant(newTypeRight));

                case OperationSymbol.GreaterThan:
                    {
                        if (key.Type == typeof(string))
                            return key.Contains(Expression.Constant(newTypeRight)); //对string 特殊处理  由于string
                        else
                            return key.GreaterThan(Expression.Constant((newTypeRight)));
                    }
                case OperationSymbol.GreaterThanOrEqual:
                    {
                        if (key.Type == typeof(string))
                            return key.Contains(Expression.Constant(newTypeRight, typeof(string)));
                        else
                            return key.GreaterThanOrEqual(Expression.Constant(newTypeRight));
                    }

                case OperationSymbol.LessThan:
                    {
                        if (key.Type == typeof(string))
                            return key.Contains(Expression.Constant(newTypeRight, typeof(string)));
                        else
                            return key.LessThan(Expression.Constant((newTypeRight)));
                    }
                case OperationSymbol.LessThanOrEqual:
                    {
                        if (key.Type == typeof(string))
                            return key.Contains(Expression.Constant(newTypeRight, typeof(string)));
                        else
                            return key.LessThanOrEqual(Expression.Constant((newTypeRight)));
                    }
                case OperationSymbol.NotEqual:
                    return key.NotEqual(Expression.Constant(newTypeRight));

                case OperationSymbol.Contains:
                    return key.Contains(Expression.Constant(newTypeRight));
            }
            throw new Exception("OperationSymbol IS NULL");
        }
    }

    /// <summary>
    /// 动态linq帮助类
    /// </summary>
    public class DynamicLinqHelper
    {
        [Display(Name = "左")]
        public string Left { get; set; }

        [Display(Name = "右")]
        public string Right { get; set; }

        [Display(Name = "运算符")]
        public OperationSymbol OperationSymbol { get; set; }

        [Display(Name = "连接符")]
        public LinkSymbol LinkSymbol { get; set; }
    }

    /// <summary>
    /// 连接符枚举（将来可能会包含 括号 ）
    /// </summary>
    public enum LinkSymbol
    {
        [Display(Name = "&&")]
        AndAlso,

        [Display(Name = "||")]
        OrElse,

        [Display(Name = "空")]
        Empty
    }

    /// <summary>
    /// 常用比较运算符 > , >= , == , < , <= , != ,Contains
    /// </summary>
    public enum OperationSymbol
    {
        [Display(Name = "Contains")]
        Contains,

        [Display(Name = ">")]
        GreaterThan,

        [Display(Name = ">=")]
        GreaterThanOrEqual,

        [Display(Name = "<")]
        LessThan,

        [Display(Name = "<=")]
        LessThanOrEqual,

        [Display(Name = "==")]
        Equal,

        [Display(Name = "!=")]
        NotEqual
    }

    #endregion 动态linq帮助类，连接符号，运算符号

    /// <summary>
    /// Linq扩展
    /// </summary>
    public static class ExpressionExtensions
    {
        #region 常用扩展方法

        /// <summary>
        /// 调用内部方法
        /// </summary>
        public static Expression Call(this Expression instance, string methodName, params Expression[] arguments)
        {
            if (instance.Type == typeof(string))
                return Expression.Call(instance, instance.Type.GetMethod(methodName, new Type[] { typeof(string) }), arguments);  //修复string contains 出现的问题 Ambiguous match found.
            else
                return Expression.Call(instance, instance.Type.GetMethod(methodName), arguments);
        }

        /// <summary>
        /// 获取内部成员
        /// </summary>
        public static Expression Property(this Expression expression, string propertyName)
        {
            // Todo:左边条件如果是dynamic，
            // 则Expression.Property无法获取子内容
            // 报错在这里，由于expression内的对象为Object，所以无法解析到
            // var x = (expression as IQueryable).ElementType;
            return Expression.Property(expression, propertyName);
        }

        /// <summary>
        /// 转Lambda
        /// </summary>
        public static Expression<TDelegate> ToLambda<TDelegate>(this Expression body,
        params ParameterExpression[] parameters)
        {
            return Expression.Lambda<TDelegate>(body, parameters);
        }

        #endregion 常用扩展方法

        #region 常用运算符 [ > , >= , == , < , <= , != , || , && ]

        /// <summary>
        /// &&
        /// </summary>
        public static Expression AndAlso(this Expression left, Expression right)
        {
            return Expression.AndAlso(left, right);
        }

        /// <summary>
        /// ||
        /// </summary>
        public static Expression OrElse(this Expression left, Expression right)
        {
            return Expression.OrElse(left, right);
        }

        /// <summary>
        /// Contains
        /// </summary>
        public static Expression Contains(this Expression left, Expression right)
        {
            return left.Call("Contains", right);
        }

        /// <summary>
        /// >
        /// </summary>
        public static Expression GreaterThan(this Expression left, Expression right)
        {
            return Expression.GreaterThan(left, right);
        }

        /// <summary>
        /// >=
        /// </summary>
        public static Expression GreaterThanOrEqual(this Expression left, Expression right)
        {
            return Expression.GreaterThanOrEqual(left, right);
        }

        /// <summary>
        /// <
        /// </summary>
        public static Expression LessThan(this Expression left, Expression right)
        {
            return Expression.LessThan(left, right);
        }

        /// <summary>
        /// <=
        /// </summary>
        public static Expression LessThanOrEqual(this Expression left, Expression right)
        {
            return Expression.LessThanOrEqual(left, right);
        }

        /// <summary>
        /// ==
        /// </summary>
        public static Expression Equal(this Expression left, Expression right)
        {
            return Expression.Equal(left, right);
        }

        /// <summary>
        /// !=
        /// </summary>
        public static Expression NotEqual(this Expression left, Expression right)
        {
            return Expression.NotEqual(left, right);
        }

        #endregion 常用运算符 [ > , >= , == , < , <= , != , || , && ]
    }

    /// <summary>
    /// Queryable扩展
    /// </summary>
    public static class QueryableExtensions
    {
        #region 自定义扩展Queryable

        /// <summary>
        /// Where扩展
        /// </summary>
        public static IEnumerable<TSource> IWhere<TSource>(this IEnumerable<TSource> source, string linqStr)
        {
            return source.Where(DynamicLinqFactory.CreateLambda<TSource>(linqStr).Compile());
        }

        /// <summary>
        /// FirstOrDefault扩展
        /// </summary>
        public static TSource IFirstOrDefault<TSource>(this IEnumerable<TSource> source, string linqStr)
        {
            return source.FirstOrDefault(DynamicLinqFactory.CreateLambda<TSource>(linqStr).Compile());
        }

        /// <summary>
        /// Count扩展
        /// </summary>
        public static Int32 ICount<TSource>(this IEnumerable<TSource> source, string linqStr)
        {
            return source.Count(DynamicLinqFactory.CreateLambda<TSource>(linqStr).Compile());
        }

        /// <summary>
        /// 自定义排序
        /// </summary>
        public static IOrderedQueryable<TSource> ISort<TSource>(this IQueryable<TSource> source, string orderByProperty, bool asc)
        {
            string command = asc ? "OrderBy" : "OrderByDescending";
            var type = typeof(TSource);
            var property = type.GetProperty(orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));
            return (IOrderedQueryable<TSource>)source.Provider.CreateQuery<TSource>(resultExpression);
        }

        /// <summary>
        /// 自定义分页
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="nowPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IQueryable<TSource> IPaging<TSource>(this IQueryable<TSource> source, int nowPage, int pageSize)
        {
            return source.ISkip((nowPage - 1) * pageSize).ITake(pageSize);
        }

        /// <summary>
        /// 自定义Skip
        /// </summary>
        public static IQueryable<TSource> ISkip<TSource>(this IQueryable<TSource> source, int count)
        {
            return source.Provider.CreateQuery<TSource>(Expression.Call(
            // 类别
            typeof(Queryable),
            // 调用的方法
            "Skip",
            // 元素类别
            new Type[] { source.ElementType },
            // 调用的表达树
            source.Expression,
            // 参数
            Expression.Constant(count)));
        }

        /// <summary>
        /// 自定义Take
        /// </summary>
        public static IQueryable<TSource> ITake<TSource>(this IQueryable<TSource> source, int count)
        {
            return source.Provider.CreateQuery<TSource>(Expression.Call(
            // 类别
            typeof(Queryable),
            // 调用的方法
            "Take",
            // 元素类别
            new Type[] { source.ElementType },
            // 调用的表达树
            source.Expression,
            // 参数
            Expression.Constant(count)));
        }

        /// <summary>
        /// 自定义去重复
        /// </summary>
        public static IEnumerable<TSource> IDistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            return source.Where(element => seenKeys.Add(keySelector(element)));
        }

        /// <summary>
        /// 动态赋值
        /// </summary>
        public static void CopyTo<T>(this object source, T target) where T : class, new()
        {
            if (source == null)
                return;

            if (target == null)
            {
                target = new T();
            }

            foreach (var property in target.GetType().GetProperties())
            {
                // 这里可以判断一下当前属性值是否为空的 source.GetType().GetProperty(property.Name).GetValue(source, null)
                target.GetType().InvokeMember(property.Name, BindingFlags.SetProperty, null, target, new object[] { source.GetType().GetProperty(property.Name).GetValue(source, null) });
            }
        }

        /// <summary>
        /// 移除特殊字段数据
        /// </summary>
        public static void RemoveSpecialPropertyValue(this object source)
        {
            var properties = source.GetType().GetProperties();
            foreach (var x in properties)
            {
                if (x.GetAccessors().Any(y => y.IsVirtual))
                {
                    source.GetType().GetProperty(x.Name).SetValue(source, null, null);
                }
            }
        }

        #endregion 自定义扩展Queryable
    }

    /// <summary>
    /// 动态表达式树
    /// 也可使用SqlSugar自带的动态表达式树
    /// </summary>
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>()
        { return f => true; }

        public static Expression<Func<T, bool>> False<T>()
        { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return expr1.OrElse(expr2, Expression.OrElse);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return expr1.AndAlso(expr2, Expression.AndAlso);
        }

        public static Expression<Func<T, bool>> AndIF<T>(this Expression<Func<T, bool>> expr1, bool where, Expression<Func<T, bool>> expr2)
        {
            if (!where)
            {
                return expr1;
            }
            //var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            //return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
            return expr1.AndAlso(expr2, Expression.AndAlso);
        }

        #region 私有方法

        private static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> expr1
            , Expression<Func<T, bool>> expr2
            , Func<Expression, Expression, BinaryExpression> func)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
        }

        private static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> expr1
            , Expression<Func<T, bool>> expr2
            , Func<Expression, Expression, BinaryExpression> func)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left, right), parameter);
        }

        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                    return _newValue;
                return base.Visit(node);
            }
        }

        #endregion 私有方法
    }
}
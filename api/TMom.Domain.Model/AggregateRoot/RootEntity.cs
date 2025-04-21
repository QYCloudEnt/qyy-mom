using TMom.Domain.Model.Entity;
using SqlSugar;

namespace TMom.Domain.Model
{
    /// <summary>
    /// 聚合根
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    public class RootEntity<Tkey> : RootField where Tkey : IEquatable<Tkey>
    {
        /// <summary>
        /// Id
        /// 泛型主键Tkey
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true)]
        public virtual Tkey Id { get; set; }
    }

    public class RootField
    {
        /// <summary>
        /// 创建人Id
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "创建人", IsOnlyIgnoreUpdate = true)]
        public int CreateId { get; set; } = 1;

        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "创建时间", IsOnlyIgnoreUpdate = true)]
        public virtual DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 版本号(并发控制)
        /// 根据实际业务情况是否启用并发控制更新，前端也要统一传入该字段
        /// </summary>
        //[SugarColumn(IsEnableUpdateVersionValidation = true, ColumnDescription = "版本号(并发控制)")]
        //public long VersionNum { get; set; } = 0;

        /// <summary>
        /// 修改人Id
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDescription = "修改人")]
        public int? UpdateId { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDescription = "修改时间")]
        public DateTime? UpdateTime { get; set; }

        #region /*************** 关联表及忽略的列 **************/

        /// <summary>
        /// 创建人表
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(CreateId))]
        [SugarColumn(IsIgnore = true)]
        [Newtonsoft.Json.JsonIgnore]
        public SysUser? CreateUserTable { get; set; } = null;

        /// <summary>
        /// 修改人表(弃用)
        /// </summary>
        //[Navigate(NavigateType.OneToOne, nameof(UpdateId))]
        //[SugarColumn(IsIgnore = true)]
        //[Newtonsoft.Json.JsonIgnore]
        //public SysUser? UpdateUserTable { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string CreateUser { get; set; } = "";

        /// <summary>
        /// 修改人
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string? UpdateUser { get; set; }

        #endregion /*************** 关联表及忽略的列 **************/

        /// <summary>
        /// 是否删除 0:未删除  1:已删除
        /// (假删除)
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "是否删除 0:未删除  1:已删除", DefaultValue = "0")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// 更新公共字段信息
        /// </summary>
        /// <param name="currentUserId">当前登录用户Id</param>
        /// <param name="isForAdded">是否新增（默认新增）</param>
        public void UpdateCommonFields(int currentUserId, bool isForAdded = true)
        {
            if (isForAdded)
            {
                CreateId = currentUserId;
                CreateTime = DateTime.Now;
            }
            else
            {
                UpdateId = currentUserId;
                UpdateTime = DateTime.Now;
            }
        }

        /// <summary>
        /// 更改删除数据字段(假删除)
        /// </summary>
        /// <param name="currentUserId">当前登录用户Id</param>
        public virtual void MarkedAsDeleted(int currentUserId)
        {
            this.IsDeleted = true;
            this.UpdateId = currentUserId;
            this.UpdateTime = DateTime.Now;
        }
    }

    public static class RootFieldUpdate
    {
        /// <summary>
        /// 批量更新公共字段信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="currentUserId">当前登录用户Id</param>
        /// <param name="isForAdded">是否新增（默认新增）</param>
        public static void UpdateCommonFields<T>(this List<T> list, int currentUserId, bool isForAdded = true) where T : RootField
        {
            list.ForEach(item => item.UpdateCommonFields(currentUserId, isForAdded));
        }

        /// <summary>
        /// 批量更改删除数据字段(假删除)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="currentUserId"></param>
        public static void MarkedAsDeleted<T>(this List<T> list, int currentUserId) where T : RootField
        {
            list.ForEach(item => item.MarkedAsDeleted(currentUserId));
        }
    }
}
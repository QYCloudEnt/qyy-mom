using SqlSugar;
using SqlSugar.DbConvert;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 工艺路线
    /// </summary>
    public class ProcessRoute : RootEntity<int>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 流程图JSON内容
        /// </summary>
        [SugarColumn(ColumnDataType = "text")]
        public string Content { get; set; } = "";

        /// <summary>
        /// 预览图地址
        /// </summary>
        public string? ImgUrl { get; set; }

        /// <summary>
        /// 作业指导书链接
        /// </summary>
        public string? SopUrl { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(20)", SqlParameterDbType = typeof(EnumToStringConvert))]
        public PublishStatusEnum Status { get; set; } = PublishStatusEnum.UnPublish;

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        [SugarColumn(IsIgnore = true)]
        public string TypeName { get; set; }

        /// <summary>
        /// 子表基础数据
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToMany, nameof(ProcessRouteBase.ProcessRouteId))]
        public List<ProcessRouteBase> ProcessRouteBases { get; set; }

        /// <summary>
        /// 子表工序顺序数据
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToMany, nameof(ProcessRouteSequence.ProcessRouteId))]
        public List<ProcessRouteSequence> ProcessRouteSequences { get; set; }
    }
}
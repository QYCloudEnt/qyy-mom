using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 组织架构表
    /// </summary>
    [SugarTable("sys_org")]
    public class SysOrg : RootEntity<int>
    {
        [SugarColumn(ColumnDescription = "组织架构代码", Length = 50)]
        public string OrgCode { get; set; }

        [SugarColumn(ColumnDescription = "组织架构名称", Length = 200)]
        public string OrgName { get; set; }

        [SugarColumn(ColumnDescription = "父组织Id")]
        public int ParentId { get; set; }
    }
}
using SqlSugar;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 维修方法表
    /// </summary>
    [SugarTable("base_repair_method")]
    public class RepairMethod : RootEntity<int>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        [SugarColumn(IsNullable = true)]
        public string Description { get; set; }
    }
}
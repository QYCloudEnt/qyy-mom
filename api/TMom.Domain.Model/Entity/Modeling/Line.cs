using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 产线表
    /// </summary>
    [SugarTable("base_line")]
    public class Line : RootEntity<int>
    {
        /// <summary>
        /// 产线编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 产线名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属车间Id
        /// </summary>
        public int WorkshopId { get; set; } = 0;

        /// <summary>
        /// 产线描述
        /// </summary>
        public string? Description { get; set; }

        [SugarColumn(IsIgnore = true)]
        [Navigate(NavigateType.OneToOne, nameof(WorkshopId))]
        public Workshop Workshop { get; set; }
    }
}
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMom.Domain.Model.Entity
{
    /// <summary>
    /// 车间表
    /// </summary>
    [SugarTable("base_workshop")]
    public class Workshop : RootEntity<int>
    {
        /// <summary>
        /// 车间编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 车间名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }
    }
}
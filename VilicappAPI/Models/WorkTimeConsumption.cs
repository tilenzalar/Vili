using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class WorkTimeConsumption
    {
        public int Id { get; set; }
        public int? WorkOrderRepairId { get; set; }
        public int? WorkTimeTypeId { get; set; }
        public string Description { get; set; }
        public decimal? Hours { get; set; }
        public decimal? PriceTotal { get; set; }
        public decimal? Price { get; set; }

        public virtual WorkOrderRepair WorkOrderRepair { get; set; }
        public virtual WorkTimeType WorkTimeType { get; set; }
    }
}

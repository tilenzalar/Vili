using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappAPI.ModelsUI
{
    public class WorkTimeConsumptionUI
    {
        public int Id { get; set; }
        public int? WorkOrderRepairId { get; set; }
        public int? WorkTimeTypeId { get; set; }
        public string Description { get; set; }
        public decimal? Hours { get; set; }
        public decimal? PriceTotal { get; set; }
        public decimal? Price { get; set; }
        public string WorkTimeTypeName { get; set; }
        public WorkTimeTypeUI WorkTimeType { get; set; }
        public int ListOrderId { get; set; }
    }
}

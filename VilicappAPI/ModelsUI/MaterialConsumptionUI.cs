using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappAPI.ModelsUI
{
    public class MaterialConsumptionUI
    {
        public int Id { get; set; }
        public int WorkOrderRepairId { get; set; }
        public string Material { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceTotal { get; set; }
        public int ListOrderId { get; set; }
    }
}

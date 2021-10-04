using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class MaterialConsumption
    {
        public int Id { get; set; }
        public int WorkOrderRepairId { get; set; }
        public string Material { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceTotal { get; set; }

        public virtual WorkOrderRepair WorkOrderRepair { get; set; }
    }
}

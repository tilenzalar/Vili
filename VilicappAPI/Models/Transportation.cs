using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class Transportation
    {
        public int Id { get; set; }
        public int WorkOrderRepairId { get; set; }
        public string Relation { get; set; }
        public decimal? Kilometers { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceTotal { get; set; }

        public virtual WorkOrderRepair WorkOrderRepair { get; set; }
    }
}

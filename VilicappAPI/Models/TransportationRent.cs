using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class TransportationRent
    {
        public int Id { get; set; }
        public int WorkOrderRentId { get; set; }
        public string Relation { get; set; }
        public decimal? Kilometers { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceTotal { get; set; }
        public bool? FixedCost { get; set; }

        public virtual WorkOrderRent WorkOrderRent { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappAPI.ModelsUI
{
    public class TransportationRentUI
    {
        public int Id { get; set; }
        public int WorkOrderRentId { get; set; }
        public string Relation { get; set; }
        public decimal? Kilometers { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceTotal { get; set; }
        public bool? FixedCost { get; set; }
    }
}

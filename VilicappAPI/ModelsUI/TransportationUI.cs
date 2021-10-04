using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappAPI.ModelsUI
{
    public class TransportationUI
    {
        public int Id { get; set; }
        public int WorkOrderRepairId { get; set; }
        public string Relation { get; set; }
        public decimal? Kilometers { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceTotal { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappAPI.ModelsUI
{
    public class RentDetailUI
    {
        public int Id { get; set; }
        public int WorkOrderRentId { get; set; }
        public decimal? RentDays { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceTotal { get; set; }
    }
}

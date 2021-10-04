using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class RentDetail
    {
        public int Id { get; set; }
        public int WorkOrderRentId { get; set; }
        public decimal? RentDays { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceTotal { get; set; }

        public virtual WorkOrderRent WorkOrderRent { get; set; }
    }
}

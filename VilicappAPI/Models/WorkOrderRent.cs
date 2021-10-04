using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class WorkOrderRent
    {
        public WorkOrderRent()
        {
            RentDetails = new HashSet<RentDetail>();
            TransportationRents = new HashSet<TransportationRent>();
        }

        public int Id { get; set; }
        public string Company { get; set; }
        public string VehicleName { get; set; }
        public DateTime? RentStart { get; set; }
        public DateTime? RentEnd { get; set; }
        public string Note { get; set; }
        public decimal? PriceTotal { get; set; }
        public string TaxNumber { get; set; }
        public string Contact { get; set; }
        public int WorkOrderStatusId { get; set; }
        public bool Deleted { get; set; }
        public int? ModifiedByUserId { get; set; }
        public DateTime ModifiedTime { get; set; }

        public virtual User ModifiedByUser { get; set; }
        public virtual WorkOrderStatus WorkOrderStatus { get; set; }
        public virtual ICollection<RentDetail> RentDetails { get; set; }
        public virtual ICollection<TransportationRent> TransportationRents { get; set; }
    }
}

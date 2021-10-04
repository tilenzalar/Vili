using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class WorkOrderTransport
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Brand { get; set; }
        public string LicenseNr { get; set; }
        public DateTime? WorkOrderDate { get; set; }
        public string RelationName { get; set; }
        public decimal? RelationKm { get; set; }
        public decimal? RelationKmPrice { get; set; }
        public int? ToolsQty { get; set; }
        public decimal? ToolsQtyPrice { get; set; }
        public int? AdditionalWorkQty { get; set; }
        public decimal? AdditionalWorkPrice { get; set; }
        public decimal? AsistanceHours { get; set; }
        public decimal? AsistanceHourPrice { get; set; }
        public string Note { get; set; }
        public decimal? PriceTotal { get; set; }
        public string TaxNumber { get; set; }
        public string Contact { get; set; }
        public int WorkOrderStatusId { get; set; }
        public bool Deleted { get; set; }
        public int? ModifiedByUserId { get; set; }
        public DateTime ModifiedTime { get; set; }
        public int? VehicleTypeId { get; set; }

        public virtual User ModifiedByUser { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual WorkOrderStatus WorkOrderStatus { get; set; }
    }
}

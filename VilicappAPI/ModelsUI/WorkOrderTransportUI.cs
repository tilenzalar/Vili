using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappAPI.ModelsUI
{
    public class WorkOrderTransportUI
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "My custom error message")]
        public string Company { get; set; }
        public int VehicleTypeId { get; set; }
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
        [Required(ErrorMessage = "My custom error message")]
        public string TaxNumber { get; set; }
        [Required(ErrorMessage = "My custom error message")]
        public string Contact { get; set; }
        public int WorkOrderStatusId { get; set; }
        public int? ModifiedByUserId { get; set; }
        public VehicleTypeUI vehicleType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappAPI.ModelsUI
{
    public class WorkOrderRentUI
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "My custom error message")]
        public string Company { get; set; }
        [Required(ErrorMessage = "My custom error message")]
        public string VehicleName { get; set; }
        public DateTime? RentStart { get; set; }
        public DateTime? RentEnd { get; set; }
        public string Note { get; set; }
        public decimal? PriceTotal { get; set; }
        [Required(ErrorMessage = "My custom error message")]
        public string TaxNumber { get; set; }
        [Required(ErrorMessage = "My custom error message")]
        public string Contact { get; set; }
        public int WorkOrderStatusId { get; set; }
        public int? ModifiedByUserId { get; set; }

        public List<RentDetailUI> RentDetails { get; set; }
        public List<TransportationRentUI> TransportationRents { get; set; }
    }
}

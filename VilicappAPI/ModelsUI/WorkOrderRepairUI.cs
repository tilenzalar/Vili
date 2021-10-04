using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappAPI.ModelsUI
{
    public class WorkOrderRepairUI
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "My custom error message")]
        public string Client { get; set; }
        [Required(ErrorMessage = "My custom error message")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "My custom error message")]
        public string ForkliftName { get; set; }
        public DateTime? Recieved { get; set; }
        public DateTime? EndWork { get; set; }
        public int? OrderTypeId { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public decimal? PriceTotal { get; set; }
        [Required(ErrorMessage = "My custom error message")]
        public string TaxNumber { get; set; }
        public bool HasAttachment { get; set; }
        public int WorkOrderStatusId { get; set; }
        public OrderTypeUI OrderType { get; set; }
        public int? ModifiedByUserId { get; set; }
        public List<WorkTimeConsumptionUI> WorkTimeConsumptions { get; set; }
        public List<MaterialConsumptionUI> MaterialConsumptions { get; set; }
        public List<TransportationUI> Transportations { get; set; }
    }
}

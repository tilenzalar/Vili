using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class WorkOrderRepair
    {
        public WorkOrderRepair()
        {
            Attachments = new HashSet<Attachment>();
            Images = new HashSet<Image>();
            MaterialConsumptions = new HashSet<MaterialConsumption>();
            Transportations = new HashSet<Transportation>();
            WorkTimeConsumptions = new HashSet<WorkTimeConsumption>();
        }

        public int Id { get; set; }
        public string Client { get; set; }
        public string Contact { get; set; }
        public string ForkliftName { get; set; }
        public DateTime? Recieved { get; set; }
        public DateTime? EndWork { get; set; }
        public int? OrderTypeId { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public decimal? PriceTotal { get; set; }
        public string TaxNumber { get; set; }
        public int WorkOrderStatusId { get; set; }
        public bool Deleted { get; set; }
        public int? ModifiedByUserId { get; set; }
        public DateTime ModifiedTime { get; set; }

        public virtual User ModifiedByUser { get; set; }
        public virtual OrderType OrderType { get; set; }
        public virtual WorkOrderStatus WorkOrderStatus { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<MaterialConsumption> MaterialConsumptions { get; set; }
        public virtual ICollection<Transportation> Transportations { get; set; }
        public virtual ICollection<WorkTimeConsumption> WorkTimeConsumptions { get; set; }
    }
}

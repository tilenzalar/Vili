using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class WorkOrderStatus
    {
        public WorkOrderStatus()
        {
            WorkOrderRents = new HashSet<WorkOrderRent>();
            WorkOrderRepairs = new HashSet<WorkOrderRepair>();
            WorkOrderTransports = new HashSet<WorkOrderTransport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WorkOrderRent> WorkOrderRents { get; set; }
        public virtual ICollection<WorkOrderRepair> WorkOrderRepairs { get; set; }
        public virtual ICollection<WorkOrderTransport> WorkOrderTransports { get; set; }
    }
}

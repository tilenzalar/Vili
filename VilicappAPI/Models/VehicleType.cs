using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            WorkOrderTransports = new HashSet<WorkOrderTransport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WorkOrderTransport> WorkOrderTransports { get; set; }
    }
}

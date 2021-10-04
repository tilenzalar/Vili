using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class OrderType
    {
        public OrderType()
        {
            WorkOrderRepairs = new HashSet<WorkOrderRepair>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WorkOrderRepair> WorkOrderRepairs { get; set; }
    }
}

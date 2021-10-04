using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class WorkTimeType
    {
        public WorkTimeType()
        {
            WorkTimeConsumptions = new HashSet<WorkTimeConsumption>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WorkTimeConsumption> WorkTimeConsumptions { get; set; }
    }
}

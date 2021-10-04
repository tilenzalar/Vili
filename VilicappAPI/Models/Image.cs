using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkOrderRepairId { get; set; }
        public byte[] BinaryData { get; set; }

        public virtual WorkOrderRepair WorkOrderRepair { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappAPI.ModelsUI
{
    public class AttachmentUI
    {
        public int Id { get; set; }
        public int WorkOrderRepairId { get; set; }
        public byte[] BinaryData { get; set; }
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappAPI.ModelsUI
{
    public class ForkLiftUI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ForkLiftTypeId { get; set; }
        public string ForkLiftTypeName { get; set; }
        public string Description { get; set; }
        public string InternalNumber { get; set; }
        public bool IsDeleted { get; set; }
    }
}

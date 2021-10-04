using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class ForkLiftType
    {
        public ForkLiftType()
        {
            ForkLifts = new HashSet<ForkLift>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ForkLift> ForkLifts { get; set; }
    }
}

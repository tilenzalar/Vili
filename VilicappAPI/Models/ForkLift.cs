using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class ForkLift
    {
        public ForkLift()
        {
            ForkLiftRents = new HashSet<ForkLiftRent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ForkLiftTypeId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public string InternalNumber { get; set; }

        public virtual ForkLiftType ForkLiftType { get; set; }
        public virtual ICollection<ForkLiftRent> ForkLiftRents { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class ForkLiftRent
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public int ForkLiftId { get; set; }
        public bool IsFinished { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public DateTime? EndRent { get; set; }
        public DateTime? StartRent { get; set; }

        public virtual ForkLift ForkLift { get; set; }
    }
}

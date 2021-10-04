using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappAPI.ModelsUI
{
    public class ForkLiftRentUI
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public int ForkLiftId { get; set; }
        public string ForkLiftName { get; set; }
        public DateTime? StartRent { get; set; }
        public DateTime? EndRent { get; set; }
        public bool IsFinished { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public string ForkLiftExtendedName { get; set; }
    }
}

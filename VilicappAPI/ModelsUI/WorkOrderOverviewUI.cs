using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappAPI.ModelsUI
{
    public class WorkOrderOverviewUI
    {
        public int Id { get; set; }
        public string WorkOrderType { get; set; }  
        public string Company { get; set; }
        public DateTime? DateModified { get; set; }
        public string Status { get; set; }
        public decimal? PriceTotal { get; set; }
        public string ModifiedByUserName { get; set; }
        public int WorkOrderStatusId { get; set; }
    }
    public enum WorkOrderType
    {
        Repair = 1,
        Rent = 2,
        Transport = 3
    }

    public enum WorkOrderStatus
    {
        Finished = 1,
        ToConfirm = 2,
        Saved = 3
    }
}

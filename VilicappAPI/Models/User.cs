using System;
using System.Collections.Generic;

#nullable disable

namespace VilicappAPI.Models
{
    public partial class User
    {
        public User()
        {
            WorkOrderRents = new HashSet<WorkOrderRent>();
            WorkOrderRepairs = new HashSet<WorkOrderRepair>();
            WorkOrderTransports = new HashSet<WorkOrderTransport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<WorkOrderRent> WorkOrderRents { get; set; }
        public virtual ICollection<WorkOrderRepair> WorkOrderRepairs { get; set; }
        public virtual ICollection<WorkOrderTransport> WorkOrderTransports { get; set; }
    }
}

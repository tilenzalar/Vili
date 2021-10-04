using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappClient.Models
{
    public class UserClient
    {
    }
    public enum UserRole
    {
        Admin = 1,
        Worker = 2
    }
    public enum WorkOrderStatusEnum
    {
        Finished = 1,
        ToConfirm = 2,
        Saved = 3
    }
}

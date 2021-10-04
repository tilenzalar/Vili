using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilicappAPI.Models
{
    public class ReturnUserModel : User
    {
        public ReturnUserModel(User user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.Token = user.Token;
            this.Username = user.Username;
            this.RoleId = user.RoleId;
            this.Role = user.Role;
        }
    }

    public class LoggedInUserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

    }

    public class LoginRequestUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}

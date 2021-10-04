using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilicappAPI.Models;

namespace VilicappAPI.Interfaces
{
    public interface IUserService
    {
        LoggedInUserModel Login(string username, string password);
        bool Logout(string username);
    }
}

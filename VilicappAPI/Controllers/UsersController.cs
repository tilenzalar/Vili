using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VilicappAPI.Interfaces;
using VilicappAPI.Models;

namespace VilicappAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public ActionResult<LoggedInUserModel> Login([FromBody] LoginRequestUserModel loginRequestUserModel)
        {
            return _userService.Login(loginRequestUserModel.UserName, loginRequestUserModel.Password);
        }

        [HttpPost("Logout")]
        public ActionResult<bool> Logout([FromBody] string username)
        {
            return _userService.Logout(username);
        }
    }
}

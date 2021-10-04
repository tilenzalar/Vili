using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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


namespace VilicappAPI.Services
{
    public class UserService : IUserService
    {
        private readonly VilicAppDbContext _context;
        private readonly JWTSettings _jwtSettings;

        public UserService(VilicAppDbContext context, IOptions<JWTSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }
        public LoggedInUserModel Login(string username, string password)
        {
            var user =  _context.Users.Include(u => u.Role)
                        .Where(u => u.Username == username && u.Password == ComputeSha256Hash(password)).FirstOrDefault();

            if (user == null)
            {
                return new LoggedInUserModel
                {
                    Id = 0,
                    UserName = "",
                    Token = "",
                    RoleId = 0,
                    RoleName = ""
                };
            }

            var tmp = new LoggedInUserModel
            {
                Id = user.Id,
                Token = user.Token,
                UserName = user.Username,
                RoleId = user.RoleId,
                RoleName = user.Role.Name
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Convert.ToString(tmp.UserName))
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            tmp.Token = tokenHandler.WriteToken(token);
            user.Token = tmp.Token;
            _context.SaveChanges();

            return tmp;
        }

        public bool Logout(string username)
        {
            var user = _context.Users.Where(u => u.Username == username).FirstOrDefault();

            if (user == null)
            {
                return false;
            }

            user.Token = "";
            _context.SaveChanges();

            return true;
        }
        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return "nf8223t57f$d2" + builder.ToString() + "asd234rf37vfb394fvh92wqf3/#cfs";
            }
        }
    }
}

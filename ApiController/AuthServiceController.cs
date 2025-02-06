using AppointmentManagmentApi.DataConnection.AppointmentManagmentApi.DataConnection;
using AppointmentManagmentApi.Models;
using AppointmentManagmentApi.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using System.Security.Cryptography;

namespace AppointmentManagmentApi.Api
{



    [Route("api/[controller]")]
    [ApiController]
    public class AuthServiceController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogin _userService;

        public AuthServiceController(IConfiguration config, ILogin userService)
        {
            _config = config;
            _userService = userService;
        }
        private readonly string _secretKey = "asdfghjtyujnjhdfjadfjadgf";
         

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] UserLoginModel user)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var dbUser = _userService.GetUserByUsername(user.Username);
            if (dbUser != null)
            {
                var token = GenerateJwtToken(user.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials");
        }

         
        private string GenerateJwtToken(string username)
        { 
            var secretKeyBytes = Encoding.UTF8.GetBytes(_secretKey);
             
            if (secretKeyBytes.Length < 32)
            { 
                using (var sha256 = SHA256.Create())
                {
                    secretKeyBytes = sha256.ComputeHash(secretKeyBytes);  
                }
            }
             
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())   
    };
             
            var key = new SymmetricSecurityKey(secretKeyBytes);  
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);   

            // Define the token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),  
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
             
            var token = tokenHandler.CreateToken(tokenDescriptor); 
            return tokenHandler.WriteToken(token);
        }

        public class UserLoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}

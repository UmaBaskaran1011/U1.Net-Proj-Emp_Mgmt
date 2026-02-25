using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeManagement.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagement.Domain.Service
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
             _configuration = configuration;
            
        }

        public string CreateToken (ApplicationUser user)
        {
            
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            
            var  signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);


             var claims= new List<Claim> {
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Name, user.Name), 
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, user.Email),    
                    new Claim (ClaimTypes.Role, user.Role)                             
             };
            var tokenDescriptor = new JwtSecurityToken(
               issuer:_configuration["Jwt:Issuer"], 
               audience: _configuration["Jwt : Audience"],
                claims: claims,
                signingCredentials : signingCredentials,  
                expires: DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("Jwt: Expirationtime"))
            );
            
            var handler = new JwtSecurityTokenHandler();
            string token  = handler.WriteToken(tokenDescriptor);
            return token;

        }

    }

}
using EmployeeManagement.Data.Data;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Controller
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {

     private readonly ApplicationDbContext _dbContext;
     private readonly JwtService _jwtService;
      public AuthController(ApplicationDbContext dbContext, JwtService jwtService)
        {
            _dbContext = dbContext;
            _jwtService = jwtService;
        } 

    [HttpPost]
      
      public async Task<string> Login(LoginDto loginUser)
      {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == loginUser.Email );
        
            if (user == null)
            {
                return ("Invalid Credentials");            
            }
            
            string token  = _jwtService.CreateToken(user);
            return  token;
      }
    }
}
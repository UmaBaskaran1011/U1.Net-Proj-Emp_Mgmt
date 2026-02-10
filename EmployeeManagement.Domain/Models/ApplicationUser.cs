using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Domain.Models
{
    public class ApplicationUser 
    {
       public int Id{get; set;}
        public required string Name { get; set; }
        public required string Email {get; set;}
        public required string Password{get; set;}

        public required string Role{get; set;}
      
    }
}
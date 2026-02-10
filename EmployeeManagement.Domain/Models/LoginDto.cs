using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Models
{
    public class LoginDto
    {
       
        public required string Email {get; set;}

        public required string Password {get; set;}
    }
}
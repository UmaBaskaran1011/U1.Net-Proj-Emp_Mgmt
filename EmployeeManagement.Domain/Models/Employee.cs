using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Models{

    public class Employee
    {
        [Key]
        public int EmployeeId {get; set;}
        [Required]
        public required string Name {get; set;} 
        public string ?Email{get; set;}
        public string ?PhoneNo{get; set;}
        public string ?Address{get; set;}

    }
}

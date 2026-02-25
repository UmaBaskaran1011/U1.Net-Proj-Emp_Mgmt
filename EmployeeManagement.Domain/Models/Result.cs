namespace EmployeeManagement.Domain.Models
{
    public  class Result
    {
        public bool? IsSuccess {get; set;}
        public string? Message {get; set;}
        public Employee? Edata {get;set;}

    }
}
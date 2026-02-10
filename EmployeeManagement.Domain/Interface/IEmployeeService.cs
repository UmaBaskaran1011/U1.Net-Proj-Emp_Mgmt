
using EmployeeManagement.Domain.Models;

public interface IEmployeeService
{
   Task< List<Employee>> GetAllEmployees ();
   Task<object> GetEmployeeById(int id);
   Task <string> AddEmployee(Employee employee);
   Task<string> UpdateEmployee(int id, Employee employee);
   Task<string> DeleteEmployee (int id);

}
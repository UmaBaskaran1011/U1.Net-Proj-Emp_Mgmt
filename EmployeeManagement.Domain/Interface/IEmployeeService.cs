
using EmployeeManagement.Domain.Models;

public interface IEmployeeService
{
   Task< List<Employee>> GetAllEmployees ();
   Task<Result> GetEmployeeById(int id);
   Task <Result> AddEmployee(Employee employee);
   Task<Result> UpdateEmployee(int id, Employee employee);
   Task<Result> DeleteEmployee (int id);

}
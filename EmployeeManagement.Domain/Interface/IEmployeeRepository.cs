using EmployeeManagement.Domain.Models;
namespace EmployeeManagement.Domain.Interface{
public interface IEmployeeRepository
{
       Task< List<Employee>> GetAllAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
       Task<bool> AddEmployeeAsync(Employee employee);
       Task<bool> UpdateEmployeeAsync(Employee employee);
       Task<bool> DeleteEmployee (Employee employee);
}
}
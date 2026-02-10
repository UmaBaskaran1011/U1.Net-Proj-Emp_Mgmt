using System.Collections.Specialized;
using System.Text;
using EmployeeManagement.Domain.Interface;
using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Domain.Service
{
    public class EmployeeService:IEmployeeService
    {

        private readonly IEmployeeRepository _repo;
        public EmployeeService (IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
              return await _repo.GetAllAsync();   
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<string> AddEmployee(Employee employee)
        {
            try
            {
                var result = await _repo.AddEmployeeAsync(employee);
                return "Employee Created";
            }
            catch(Exception)
            {
                throw ;
            }
        }
    
       public async Task<object> GetEmployeeById(int id)
        {
            try{
                if(id<=0)
                {
                    return "Invalid Employee Id";
                }
                           
                var employee = await _repo.GetEmployeeByIdAsync(id);
                if(employee == null)
                {
                    return "Employee Not Found";
                }
                 return employee;          
            }
            catch(Exception ex)
            {
               throw new Exception (ex.ToString()); 
            } 
        }

        public async Task<string> UpdateEmployee(int id, Employee emp)
        {
            try
            {
                if(id<=0)
                {
                    return "Invalid empid";
                }
                var existingEmployee= await _repo.GetEmployeeByIdAsync(id);
                if(existingEmployee == null)
                {  return "Employee NotFound"; }

                existingEmployee.Name = emp.Name;
                existingEmployee.Address = emp.Address;
                existingEmployee.Email = emp.Email;
                existingEmployee.PhoneNo = emp.PhoneNo;

                var result = await  _repo.UpdateEmployeeAsync(existingEmployee);

                return "Employee Details Updated";
            }
            catch(Exception)
            {
              throw ;
            }
            
        }

        public async Task<string> DeleteEmployee (int empid)
        {
            if(empid<0)
            {
                return "Invalid empid";
            }
            var employee = await _repo.GetEmployeeByIdAsync(empid);
            if(employee!= null)
            {
            var result = await _repo.DeleteEmployee(employee);
            return "Employee Deleted";
            }
            else return "Employee Not Found ";
        }
    }


}
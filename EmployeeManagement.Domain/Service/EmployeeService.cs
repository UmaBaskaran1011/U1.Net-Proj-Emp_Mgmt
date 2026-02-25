using System.Collections.Specialized;
using System.Text;
using EmployeeManagement.Domain.Interface;
using EmployeeManagement.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeManagement.Domain.Service
{
    public class EmployeeService:IEmployeeService
    {

        private readonly IEmployeeRepository _repo;
        public EmployeeService (IEmployeeRepository repo )
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

        public async Task<Result> AddEmployee(Employee employee)
        {
            try
            {
                var Added = await _repo.AddEmployeeAsync(employee); 
                Result result = new Result();
                if(Added)
                {
                    result.IsSuccess = true;
                    result.Message = employee.Name + "- Employee Created";                  
                }  
                return result;                        
            }
            catch(Exception ex)
            {
                return new Result{ IsSuccess= false, Message= ex.Message } ;
            }
        }
    
       public async Task<Result> GetEmployeeById(int id)
        {
            try{
                Result result = new Result();              
                if(id<=0)
                {
                   return new Result{ IsSuccess= false, Message="Invalid Employee Id"};

                }                           
                var employee = await _repo.GetEmployeeByIdAsync(id);
                if(employee != null)
                {
                    result.IsSuccess= true;       
                    result.Message="Employee Data fetched";    
                    result.Edata =employee;
                }
                else
                {
                    return new Result{ IsSuccess= false, Message="Employee Not Found"};
                }                     
                return result;          
            }

            catch(Exception ex)
            {
               return new Result{ IsSuccess = false, Message= ex.Message};
            } 
        }

        public async Task<Result> UpdateEmployee(int id, Employee emp)
        {
            try
            {
                Result response = new Result();
                if(id<=0)
                {
                    return new Result{ IsSuccess= false, Message="Invalid Employee Id"};
                }
                var existingEmployee= await _repo.GetEmployeeByIdAsync(id);
                if(existingEmployee == null)
                {  
                    return new Result{ IsSuccess= false, Message="Employee Not Found"};
                }

                existingEmployee.Name = emp.Name;
                existingEmployee.Address = emp.Address;
                existingEmployee.Email = emp.Email;
                existingEmployee.PhoneNo = emp.PhoneNo;

                var result = await  _repo.UpdateEmployeeAsync(existingEmployee);
                if(result)
                {
                    response.IsSuccess= true;
                    response.Message="Employee Data Updated";
                }
                return response;
            }
            catch(Exception ex)
            {
              return new Result{IsSuccess= false, Message=ex.Message};
            }
            
        }

        public async Task<Result> DeleteEmployee (int empid)
        {
            try
            {
                if(empid<=0)
                {
                    //return new Result{ IsSuccess= false, Message="Invalid Employee Id"};
                    throw new InvalidDataException("Invalid Employee Id");
                }
                var employee = await _repo.GetEmployeeByIdAsync(empid);

                if(employee!= null)
                {
                    await _repo.DeleteEmployee(employee);
                    return new Result{IsSuccess= true, Message="Employee Data Deleted"};
                }
                else throw  new KeyNotFoundException ("Employee Not Found");
            }
             catch(Exception ex)
            {
              return new Result{IsSuccess= false, Message=ex.Message};
            }           
        }
    }


}
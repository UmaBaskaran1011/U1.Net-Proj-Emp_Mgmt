using EmployeeManagement.Data.Data;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Data.Repository{

    public class EmployeeRepo : IEmployeeRepository
    {
         private readonly ApplicationDbContext _context;

         public EmployeeRepo(ApplicationDbContext context)
        {
             _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<bool> AddEmployeeAsync(Employee emp)
        {
            try
            {
                _context.Employees.Add(emp);
               return await _context.SaveChangesAsync() > 0;
            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
                    
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e=> e.EmployeeId == id);

        }

        public async Task<bool> DeleteEmployee(Employee employee)
        {
           _context.Employees.Remove(employee);          
            return  await  _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);            
            return await _context.SaveChangesAsync() > 0 ; 
        }
    }
} 

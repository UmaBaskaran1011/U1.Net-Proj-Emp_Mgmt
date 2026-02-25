using System;
using EmployeeManagement.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controller
{
    [Authorize] 
    [ApiController]
    [Route("api/[controller]")]
     public class EmployeeController:ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAllEmployees());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var result =  await _service.GetEmployeeById(id);               
                if(result.Message == "Invalid Employee Id")
                {
                    return BadRequest(result);
                }
                else if(result.Message == "Employee Not Found")
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee (Employee employee)
        {
            try
            {
                Result message = await _service.AddEmployee(employee);
              
                return Ok(message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Error"+ex.Message);              
            }
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee emp)
        {
            try
            {
                Result result = await _service.UpdateEmployee(id, emp);                
                if(result.Message == "Employee Not Found")
                {
                    return NotFound(result);
                }
                else if(result.Message == "Invalid Employee Id")
                {
                    return BadRequest(result);
                }
                else return Ok (result);          
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try{
                var message = await _service.DeleteEmployee(id);
                if(message.Message == "Employee Not Found")
                {
                    return NotFound(message);
                }
                else if (message.Message == "Invalid Employee Id")
                {
                    return BadRequest(message);
                }
                else return Ok(message);  
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }         
        }
    }
}
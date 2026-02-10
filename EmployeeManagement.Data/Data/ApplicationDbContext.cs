using EmployeeManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EmployeeManagement.Data.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
    public DbSet<Employee> Employees { get; set;}

    public DbSet<ApplicationUser> Users {get; set;}
}
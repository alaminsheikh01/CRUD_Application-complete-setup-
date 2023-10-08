using CRUD_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Application.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}

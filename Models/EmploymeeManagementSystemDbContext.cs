using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeManagementSystemDbContext : DbContext
    {
        public EmployeeManagementSystemDbContext(DbContextOptions<EmployeeManagementSystemDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("text");
            }

        }

    }
}
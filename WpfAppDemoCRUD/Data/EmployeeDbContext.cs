using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppDemoCRUD.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(GetEmployees());
            base.OnModelCreating(modelBuilder);
        }

        private Employee[] GetEmployees()
        {
            return new Employee[]
            {
                new Employee { Id = 1, Name = "John Smith", Job_Title = "CEO", Salary = 10000, Contract_Period =50},
                new Employee { Id = 2, Name = "Andrew Garcia", Job_Title = "Manager", Salary = 5000, Contract_Period =2},
                new Employee { Id = 3, Name = "Amalia Johnson", Job_Title = "Doctor", Salary = 4000, Contract_Period =3},
                new Employee { Id = 4, Name = "Adela Stark", Job_Title = "Surgeon ", Salary = 4500, Contract_Period =5},
            };
        }
    }
}

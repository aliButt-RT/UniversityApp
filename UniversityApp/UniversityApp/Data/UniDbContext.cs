using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System;
using UniversityApp.Models;

namespace UniversityApp.Data
{
    public class UniDbContext:DbContext
    {
        //public UniDbContext()
        //{
        //    Database.
        //}

        //connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=University; Integrated Security = True;");
        }


        //Dbset
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}


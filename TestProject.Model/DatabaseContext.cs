using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Entity.Entity;

namespace TestProject.Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseOracle("");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("STUDENT");
            modelBuilder.Entity<Employee>().ToTable("EMPLOYEE");

            ToUpper(modelBuilder);
        }

        private void ToUpper(ModelBuilder modelBuilder)
        {
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var prop in item.GetProperties())
                {
                    prop.SetColumnName(prop.GetColumnName().ToUpperInvariant());
                }
            }
        }
    }
}

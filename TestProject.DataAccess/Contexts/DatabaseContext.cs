using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Entity.Entity;

namespace TestProject.DataAccess.Contexts
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
            //optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.250.65.52)(PORT=1722)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=GISTST)));User Id=NAIMOLCER;Password=Ng53Qtm3QmgnTmbU;");
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

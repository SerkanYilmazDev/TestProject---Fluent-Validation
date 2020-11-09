using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Entity.Entity
{
    public class Employee : Person
    {
        public double Salary { get; set; }
        public int DeptId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestProject.Entity.Entity
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool IsDelete { get; set; }
    }
}

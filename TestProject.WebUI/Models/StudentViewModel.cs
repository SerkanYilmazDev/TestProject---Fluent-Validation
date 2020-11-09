using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.WebUI.Models
{
    public class StudentViewModel
    {
        //[Required(ErrorMessage = "Personel Adı boş bırakılamaz")]
        public string PersonName { get; set; }

        //[Required(ErrorMessage = "Adres boş bırakılamaz")]
        //[MinLength(10, ErrorMessage = "Adres minimum 10 karakter olmalıdır")]
        public string Address { get; set; }

        //[Required(ErrorMessage = "Telefon boş bırakılamaz")]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessage = "Eposta boş bırakılamaz")]
        //[DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        //[Required(ErrorMessage = "Üniversite Adı boş bırakılamaz")]
        public string UniverstyName { get; set; }

        //[Required(ErrorMessage = "Derece boş bırakılamaz")]
        //[Range(0, 100)]
        public string Degree { get; set; }
    }
}

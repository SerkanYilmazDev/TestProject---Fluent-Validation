using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Entity.Entity;

namespace TestProject.Business.ValidationRules.FluentValidation
{
    public class StudentValidaton : AbstractValidator<Student>
    {
        public StudentValidaton()
        {
            RuleFor(s => s.PersonName).NotEmpty().WithMessage("Personel adı Zorunludur");
            RuleFor(s => s.PhoneNumber).NotEmpty().WithMessage("Telefon no Zorunludur");
            RuleFor(s => s.UniverstyName).NotEmpty().WithMessage("Üniversite adı Zorunludur");
            RuleFor(s => s.EmailAddress).NotEmpty().WithMessage("Eposta Zorunludur");
            RuleFor(s => s.Degree).NotEmpty().WithMessage("Derece Zorunludur")
                .When(x => Convert.ToInt32(x.Degree) > 0 || Convert.ToInt32(x.Degree) < 100)
                .WithMessage("Derece 0 - 100 arasında olmalıdır");

            RuleFor(s => s.Address).NotEmpty().WithMessage("Adres Zorunludur");

            RuleFor(s => s.Address).Must(StartWithA);

        }

        private bool StartWithA(string arg)
        {
            if (string.IsNullOrEmpty(arg))
            {
                return false;
            }
            return arg.StartsWith("A");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Business.Abstract;
using TestProject.Business.Concreate;
using TestProject.Entity.Entity;
using TestProject.Repository.Repository;
using TestProject.WebUI.Models;
using TestProject.WebUI.ValidationRule.FluentValidation;

namespace TestProject.WebUI.Controllers
{
    public class StudentController : Controller
    {
        IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            _studentService.Add(new Entity.Entity.Student());

            var studentViewModel = new StudentViewModel();

            return View(studentViewModel);
        }

        [HttpPost]
        public IActionResult Index(StudentViewModel model)
        {
            //StudentValidator studentValidator = new StudentValidator();
            //var result = studentValidator.Validate(model);

            //if (!result.IsValid)
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }
            //}

            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

    }
}

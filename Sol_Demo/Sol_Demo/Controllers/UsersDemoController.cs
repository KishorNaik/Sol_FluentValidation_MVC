using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Sol_Demo.ViewModels;

namespace Sol_Demo.Controllers
{
    public class UsersDemoController : Controller
    {

        private readonly IValidator<UsersViewModel> validator = null;

        public UsersDemoController(IValidator<UsersViewModel> validator)
        {
            this.validator = validator;
            UserVM = new UsersViewModel();
        }

        [BindProperty]
        public UsersViewModel UserVM { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> OnSubmit()
        {
            var validatonResult = await validator.ValidateAsync(UserVM, ruleSet: "UserRegistration");

            validatonResult.AddToModelState(base.ModelState, null);

            if (base.ModelState.IsValid == true)
            {
                // Redirect or Something you want to do.
            }

            return View("Index", UserVM);
        }
    }
}
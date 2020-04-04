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
    public class ParentChildDemoController : Controller
    {
        private readonly IValidator<ParentChildViewModel> validator = null;

        public ParentChildDemoController(IValidator<ParentChildViewModel> validator)
        {
            this.validator = validator;
        }

        [BindProperty]
        public ParentChildViewModel ParentChildVM { get; set; }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnSubmit()
        {
            var validationResult = await this.validator.ValidateAsync(ParentChildVM, ruleSet: "ParentChildValidation");

            validationResult.AddToModelState(base.ModelState, null);

            if (base.ModelState.IsValid == true)
            {
                // Redirect or Do Something
            }

            return View("Index", ParentChildVM);
        }
    }
}
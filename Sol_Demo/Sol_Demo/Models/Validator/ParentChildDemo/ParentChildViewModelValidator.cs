using FluentValidation;
using Sol_Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Models.Validator.ParentChildDemo
{
    public class ParentChildViewModelValidator : AbstractValidator<ParentChildViewModel>
    {
        public ParentChildViewModelValidator()
        {
            RuleSet("ParentChildValidation", () =>
            {
                RuleFor(x => x.Parent)
                .SetValidator(new ParentModelValidator());
            });

            
        }
    }
}

using FluentValidation;
using Sol_Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Models.Validator.UsersDemo
{
    public class UserViewModelValidator : AbstractValidator<UsersViewModel>
    {
        public UserViewModelValidator()
        {
            RuleSet("UserRegistration", () =>
            {
                RuleFor(x => x.Users)
                    .SetValidator(new UserModelValidator());
            });
        }
    }
}

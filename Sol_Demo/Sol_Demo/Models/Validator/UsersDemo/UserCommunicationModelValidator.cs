using FluentValidation;
using Sol_Demo.Models.CustomValidator;
using Sol_Demo.Models.UsersPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Models.Validator.UsersDemo
{
    public class UserCommunicationModelValidator : AbstractValidator<UserCommunicationModel>
    {
        public UserCommunicationModelValidator()
        {

            RuleFor(x => x.EmailId)
                .NotEmpty()
                .EmailAddress();
                

            //RuleFor(x => x.MobileNo)
            //    .NotEmpty()
            //    .Must((leMobileNo) => leMobileNo?.Length == 10)
            //    .WithMessage("Mobile No must be 10 digit no");

            // Custom Property Validator
            RuleFor(x => x.MobileNo)
                .NotEmpty()
                .MobileNo();
        }
    }
}

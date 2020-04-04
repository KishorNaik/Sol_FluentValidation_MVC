using FluentValidation;
using Sol_Demo.Models.CustomValidator;
using Sol_Demo.Models.UsersPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Models.Validator.UsersDemo
{
    public class UserModelValidator: AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Length(50);

            RuleFor(x => x.LastName)
            .NotEmpty()
            .Length(50);

            RuleFor(x => x.UserCommunication)
                .SetValidator(new UserCommunicationModelValidator());

        }
    }
}

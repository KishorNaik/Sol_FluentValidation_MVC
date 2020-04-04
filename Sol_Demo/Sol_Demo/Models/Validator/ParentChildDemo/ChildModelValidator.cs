using FluentValidation;
using FluentValidation.Results;
using Sol_Demo.Models.ChildPoco;
using Sol_Demo.Models.CustomValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sol_Demo.Models.Validator.ParentChildDemo
{
    public class ChildModelValidator : AbstractValidator<ChildModel>
    {
        
        public ChildModelValidator()
        {
            RuleFor(x => x.ChildBirthday)
                .NotEmpty();
                
        }
    }
}

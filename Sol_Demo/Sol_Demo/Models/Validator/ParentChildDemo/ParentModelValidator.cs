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
    public class ParentModelValidator : AbstractValidator<ParentModel>
    {
        public ParentModelValidator()
        {
            RuleFor(x => x.ParentBirtday)
                .NotEmpty();

            //RuleFor(x => x.Child.ChildBirthday)
            //    .NotEmpty()
            //   .Must((leDate)=> {
            //       var date = Convert.ToDateTime(leDate);
            //       var flag= date.Equals(DateTime.Now);
            //       return flag;
            //   })
            //   .WithMessage("Start date is required");


            RuleFor(x => x.Child.ChildBirthday)
               .SetValidator(new ChildBirtdaysMustBeLaterThanParentCustomValidator());

            RuleFor(x => x.Child)
                .SetValidator(new ChildModelValidator());

        }


    }
}

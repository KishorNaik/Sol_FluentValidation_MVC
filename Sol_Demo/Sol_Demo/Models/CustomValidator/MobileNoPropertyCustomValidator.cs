using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Models.CustomValidator
{
    public class MobileNoPropertyCustomValidator : PropertyValidator
    {
        public MobileNoPropertyCustomValidator()
            :base("'{PropertyValue}' must be 10 digit no.")
        {

        }

        protected override bool IsValid(PropertyValidatorContext context)
        {

            var selfObj = context.ParentContext.InstanceToValidate;  // get Self Model Object (UserCommunication Model)


            var mobileNo = context.PropertyValue as string;

            if (String.IsNullOrEmpty(mobileNo)) return true;

            if (mobileNo?.Length == 10) return true;

            return false;
        }
    }

    public static class MobileNoPropertyCustomValidatorExtension
    {
        public static IRuleBuilderOptions<T, string> MobileNo<T>(
        this IRuleBuilder<T, string> rule
    )
        {
            return rule.SetValidator(new MobileNoPropertyCustomValidator());
        }
    }
}

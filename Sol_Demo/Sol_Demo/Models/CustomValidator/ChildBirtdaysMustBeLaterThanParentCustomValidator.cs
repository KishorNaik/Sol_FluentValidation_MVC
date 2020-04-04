using FluentValidation;
using FluentValidation.Validators;
using Sol_Demo.Models.ChildPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Demo.Models.CustomValidator
{
    public class ChildBirtdaysMustBeLaterThanParentCustomValidator : PropertyValidator
    {
        
        public ChildBirtdaysMustBeLaterThanParentCustomValidator()
        : base("Property {PropertyName} contains children born before their parent!")
        {
        
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var parent = context.ParentContext.InstanceToValidate as ParentModel;

            var childBirthday = Convert.ToDateTime(context.PropertyValue);

            if (Convert.ToDateTime( parent.ParentBirtday) > childBirthday) return false;

            return true;
        }
    }

   
}

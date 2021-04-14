using System;
using FluentValidation;
using System.Collections.Generic;
using System.Text;

namespace FoodAndGo.Data.ViewModels.Validator
{
    public class LogininputValidator:AbstractValidator<ViewModelLogin>
    {
        public LogininputValidator() { 
            RuleFor(o => o.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(o => o.Password).NotEmpty().NotNull();
            

        }
    }
}

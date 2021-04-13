using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodAndGo.Data.ViewModels.Validator
{
    public class FoodinputValidator:AbstractValidator<ViewModelFoodAdd>
    {
        public FoodinputValidator()
        {
            RuleFor(o => o.FoodName).NotEmpty().NotNull();
            RuleFor(o => o.Price).NotEmpty().NotNull(); 
            RuleFor(o => o.Stock).NotEmpty().NotNull();


        }
    }
}

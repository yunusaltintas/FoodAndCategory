using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace FoodAndGo.Data.ViewModels.Validator
{
    public class CategoryinputValidator : AbstractValidator<ViewModelCategoryAdd>
    {
        public CategoryinputValidator()
        {
            RuleFor(o => o.CategoryName).NotEmpty().NotNull();
            
        }
      

    }
}


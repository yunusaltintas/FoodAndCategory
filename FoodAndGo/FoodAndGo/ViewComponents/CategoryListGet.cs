using FoodAndGo.Data;
using FoodAndGo.Repositories;
using FoodAndGo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAndGo.ViewComponents
{
    public class CategoryListGet: ViewComponent
    {
       
        private readonly ICategoryService categoryService;

        public CategoryListGet(ICategoryService categoryService)
        {
            //_Repository = baseRepository;
            this.categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var categoryList = categoryService.List();
            return View(categoryList);
        }
    }
}

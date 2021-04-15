using FoodAndGo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAndGo.ViewComponents
{
    public class FoodListGet : ViewComponent
    {
        private readonly IFoodService _foodService;

        public FoodListGet(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public IViewComponentResult Invoke()
        {
            var FoodList = _foodService.List();
            return View(FoodList);

        }

    }
}

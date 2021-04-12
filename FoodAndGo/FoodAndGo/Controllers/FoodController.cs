using FoodAndGo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAndGo.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        public IActionResult Index()
        {
            var result = _foodService.List();
            return View(result);
        }
    }
}

using FoodAndGo.Data.ViewModels;
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
        [HttpGet]
        public IActionResult FoodAdd()
        {
            ViewBag.Category = _foodService.List();
               
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FoodAdd(ViewModelFoodAdd viewModelFood)
        {
            if (!ModelState.IsValid)
            {
                return View("FoodAdd", viewModelFood);
            }
            await _foodService.FoodAdd(viewModelFood);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> FoodDelete(int id)
        {
            await _foodService.FoodDelete(id);

            return RedirectToAction("index");
        }


    }
}

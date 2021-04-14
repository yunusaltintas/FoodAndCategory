using FoodAndGo.Data;
using FoodAndGo.Data.ViewModels;
using FoodAndGo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FoodAndGo.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly ICategoryService _categoryService;

        public FoodController(IFoodService foodService, ICategoryService categoryService)
        {
            _foodService = foodService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var result = _foodService.List();
            if (result == null)
            {
                return View();
            }
            return View(result);
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
            
            var result = _categoryService.List();
            

            ViewBag.Category = result;

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
        [HttpGet]
        public async Task<IActionResult> FoodDelete(int id)
        {
            await _foodService.FoodDelete(id);

            return RedirectToAction("index");
        }
        [HttpGet]
        public async Task<IActionResult> FoodGet(int id)
        {
            if (!ModelState.IsValid)
            {
                return View("FoodGet", id);
            }
            var result2 = _categoryService.List();
            ViewBag.Category = result2;
          
            var result = await _foodService.FoodGet(id);
          
            return View(result);
            
        }
        [HttpPost]
        public async Task<IActionResult> FoodGet(ViewModelFoodAdd viewModelFoodAdd)
        {
            if (!ModelState.IsValid)
            {
                return View("FoodGet", viewModelFoodAdd);
            }

           await _foodService.FoodUpdate(viewModelFoodAdd);

            return View();

        }



    }
}

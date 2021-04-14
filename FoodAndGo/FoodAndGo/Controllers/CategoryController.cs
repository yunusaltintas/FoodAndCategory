using FoodAndGo.Data;
using FoodAndGo.Data.ViewModels;
using FoodAndGo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAndGo.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _categoryService.List();
            return View(result);
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAdd(ViewModelCategoryAdd viewModelCategory)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd", viewModelCategory);
            }
            await _categoryService.CategoryAdd(viewModelCategory);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CategoryGet(int id)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryGet", id);
            }
            var result = await _categoryService.CategoryGet(id);

            var cat = new ViewModelCategoryAdd
            {
                CategoryName = result.CategoryName,
                CategoryDesc = result.CategoryDescp,
                id = result.Id
            };
            return View(cat);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryGet(ViewModelCategoryAdd viewModelCategory)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryGet", viewModelCategory);
            }
            await _categoryService.CategoryUpdate(viewModelCategory);

            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> CategoryDelete(int id)
        {
            bool a = await _categoryService.CategoryDelete(id);
            if (a)
            {
                return RedirectToAction("Index");
            }
            

            return View();
        }


    }
}

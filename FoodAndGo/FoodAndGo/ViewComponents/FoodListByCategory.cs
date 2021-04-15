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
    public class FoodListByCategory : ViewComponent
    {
        private readonly IFoodService _foodService;
        private readonly IBaseRepository<Food> _baseRepository;

        public FoodListByCategory(IFoodService foodService,IBaseRepository<Food> baseRepository )
        {
            _foodService = foodService;
            _baseRepository = baseRepository;
        }

        public IViewComponentResult Invoke(int id)
        {
            
            var FoodList = _baseRepository.Listt(p => p.CategoryId == id);
            return View(FoodList);

        }
    }
}

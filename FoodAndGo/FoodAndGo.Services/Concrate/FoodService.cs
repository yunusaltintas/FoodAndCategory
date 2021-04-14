using FoodAndGo.Data;
using FoodAndGo.Data.ViewModels;
using FoodAndGo.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAndGo.Services
{
    public class FoodService : IFoodService
    {
        private readonly IBaseRepository<Food> _Repository;

        public FoodService(IBaseRepository<Food> baseRepository)
        {
            _Repository = baseRepository;
        }

        public async Task FoodAdd(ViewModelFoodAdd viewModelFood)
        {
            var NewFood = new Food
            {
                FoodName = viewModelFood.FoodName,
                FoodDescp = viewModelFood.FoodDescp,
                Price = viewModelFood.Price,
                Stock = viewModelFood.Stock,
                Category = viewModelFood.Category

            };

            await _Repository.TAdd(NewFood);
        }

        public async Task FoodDelete(int id)
        {
            await _Repository.TDelete(id);
        }

        public List<Food> List()
        {

            return _Repository.TQuery().Include(x => x.Category).ToList();
        }

        public async Task<ViewModelFoodAdd> FoodGet(int id)
        {
            var result = await _Repository.TGetById(id);
            var fod = new ViewModelFoodAdd
            {
                FoodName = result.FoodName,
                FoodDescp = result.FoodDescp,
                Price = result.Price,
                Stock = result.Stock,
                id = result.Id,
                ImageUrl = result.ImageUrl

            };


            return fod;
        }

        public async Task FoodUpdate(ViewModelFoodAdd viewModelFoodAdd)
        {
            var result = new Food
            {
                Id = viewModelFoodAdd.CategoryId,
                FoodName = viewModelFoodAdd.FoodName,
                FoodDescp = viewModelFoodAdd.FoodDescp,
                Price = viewModelFoodAdd.Price,
                Stock = viewModelFoodAdd.Stock,
                ImageUrl = viewModelFoodAdd.ImageUrl,
                CategoryId = viewModelFoodAdd.CategoryId
            };

            await _Repository.TUpdate(result);
        }
    }
}


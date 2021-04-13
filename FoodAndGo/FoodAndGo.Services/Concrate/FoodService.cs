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
    public class FoodService:IFoodService
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
                FoodName =viewModelFood.FoodName,
                FoodDescp=viewModelFood.FoodDescp,
                Price=viewModelFood.Price,
                Stock=viewModelFood.Stock,
                
            };
            await _Repository.TAdd(NewFood);
        }

        public async Task FoodDelete(int id)
        {
            await _Repository.TDelete(id);
        }

        public IQueryable List()
        {
            
            return _Repository.TQuery().Include(x => x.Category);
        }
    }
}

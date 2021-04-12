using FoodAndGo.Data;
using FoodAndGo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodAndGo.Services
{
    public class FoodService:IFoodService
    {
        private readonly IBaseRepository<Food> _Repository;

        public FoodService(IBaseRepository<Food> baseRepository)
        {
            _Repository = baseRepository;
        }

        IQueryable IFoodService.List()
        {
            return _Repository.TGetAll();
        }
    }
}

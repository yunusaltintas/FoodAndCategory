using FoodAndGo.Data;
using FoodAndGo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodAndGo.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _Repository;

        public CategoryService(IBaseRepository<Category> baseRepository)
        {
            _Repository = baseRepository;
        }
        public IQueryable List()
        {
            var result = _Repository.TGetAll();
            return result;
        }
    }
}

using FoodAndGo.Data;
using FoodAndGo.Data.ViewModels;
using FoodAndGo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAndGo.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _Repository;

        public CategoryService(IBaseRepository<Category> baseRepository)
        {
            _Repository = baseRepository;
        }

        public async Task CategoryAdd(ViewModelCategoryAdd viewModelCategory)
        {
            var NewCategory = new Category
            {
                CategoryName = viewModelCategory.CategoryName,
                CategoryDescp=viewModelCategory.CategoryDesc
   
            };
            await _Repository.TAdd(NewCategory);
        }

        public async Task<Category> CategoryGet(int id)
        {
            return await _Repository.TGetById(id);
        }

        public IQueryable List()
        {
            var result = _Repository.TGetAll();
            return result;
        }

        public async Task CategoryUpdate(ViewModelCategoryAdd viewModelCategory)
        {
            var result = await _Repository.TFetchSingleAsync(x => x.Id == viewModelCategory.id);

            result.CategoryName = viewModelCategory.CategoryName;
            result.CategoryDescp = viewModelCategory.CategoryDesc;

            await _Repository.TUpdate(result);
        }


    }
}

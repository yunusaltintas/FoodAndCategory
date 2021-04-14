using FoodAndGo.Data;
using FoodAndGo.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAndGo.Services
{
    public interface ICategoryService
    {

        List<Category> List();
        Task CategoryAdd(ViewModelCategoryAdd viewModelCategory);
        Task<Category> CategoryGet(int id);
        Task CategoryUpdate(ViewModelCategoryAdd viewModelCategory);
        Task<bool> CategoryDelete(int id);
    } 
}

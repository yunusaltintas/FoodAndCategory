using FoodAndGo.Data;
using FoodAndGo.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAndGo.Services
{
    public interface IFoodService
    {
        List<Food> List();
        Task FoodAdd(ViewModelFoodAdd viewModelFood);
        Task FoodDelete(int id);
        Task<ViewModelFoodAdd> FoodGet(int id);
        Task FoodUpdate(ViewModelFoodAdd viewModelFoodAdd);
    }
}

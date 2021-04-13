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
        IQueryable List();
        Task FoodAdd(ViewModelFoodAdd viewModelFood);
        Task FoodDelete(int id);
    }
}

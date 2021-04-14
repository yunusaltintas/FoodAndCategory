using FoodAndGo.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodAndGo.Services.Abstract
{
    public interface ILoginService
    {
        Task<bool> LoginAsync(ViewModelLogin viewModelLogin);

    }
}


using FoodAndGo.Data.Entities;
using FoodAndGo.Data.ViewModels;
using FoodAndGo.Repositories;
using FoodAndGo.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodAndGo.Services.Concrate
{
    public class LoginService : ILoginService
    {
        private readonly IBaseRepository<Login> _Repository;

        public LoginService(IBaseRepository<Login> baseRepository)
        {
            _Repository = baseRepository;
        }
        public async Task<bool> LoginAsync(ViewModelLogin viewModelLogin)
        {
            var result=await _Repository.TFetchSingleAsync(x => x.Email == viewModelLogin.Email);
            //string username = "yns";
            //string email = "yunus@gmail.com";
            //string password = "123";
            if (viewModelLogin.Email==result.Email && viewModelLogin.Password==result.Password)
            {
                return true;
            }
            return false;
        }
    }
}

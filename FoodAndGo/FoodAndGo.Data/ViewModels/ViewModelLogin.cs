using System;
using System.Collections.Generic;
using System.Text;

namespace FoodAndGo.Data.ViewModels
{
    public class ViewModelLogin
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}

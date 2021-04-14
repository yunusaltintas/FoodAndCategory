using System;
using System.Collections.Generic;
using System.Text;

namespace FoodAndGo.Data.Entities
{
   public class Login:BaseEntity
    {
        public String Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

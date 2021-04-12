using System;
using System.Collections.Generic;
using System.Text;

namespace FoodAndGo.Data
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public string CategoryDescp { get; set; }

        public ICollection<Food> Foods { get; set; }

    }
}

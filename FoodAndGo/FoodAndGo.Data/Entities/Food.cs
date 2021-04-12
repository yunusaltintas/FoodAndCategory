using System;
using System.Collections.Generic;
using System.Text;

namespace FoodAndGo.Data
{
    public class Food:BaseEntity
    {
        public string FoodName { get; set; }
        public string FoodDescp { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}

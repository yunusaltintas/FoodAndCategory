using System;
using System.Collections.Generic;
using System.Text;

namespace FoodAndGo.Data
{
   public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
      

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodAndGo.Services
{
    public interface IFoodService
    {
        IQueryable List();
    }
}

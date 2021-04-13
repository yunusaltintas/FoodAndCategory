using FoodAndGo.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;

namespace FoodAndGo.Repositories
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        Task<T> TAdd(T Entity);
        IQueryable<T> TGetAll();
        IQueryable<T> TQuery();
        Task<bool> TDelete(int id);
        Task<bool> TUpdate(T Entity);
        Task<T> TGetById(int id);
        Task<T> TFetchSingleAsync(Expression<Func<T,bool>> predicate);



    }   
}

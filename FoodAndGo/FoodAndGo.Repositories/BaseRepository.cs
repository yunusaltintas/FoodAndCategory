using System;
using FoodAndGo.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FoodAndGo.Repositories
{
    
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly FoodAndGoContext _context;
        private readonly DbSet<T> _db;

        public BaseRepository(FoodAndGoContext foodAndGoContext )
        {
            _context = foodAndGoContext;
            _db = _context.Set<T>();
        }
        public async Task<T> TAdd(T Entity)
        {
            await _db.AddAsync(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        public async Task<bool> TDelete(int id)
        {
            var result = await _db.FindAsync(id);
            if (result==null)
            {
                return false;
            }
            _db.Remove(result);
            await _context.SaveChangesAsync();
          
            return true;
        }

        public async Task<T> TFetchSingleAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _db.Where(predicate).FirstOrDefaultAsync();
            return result;
        }

        public IQueryable<T> TGetAll()
        {
            return _db.AsNoTracking();
        }

        public IQueryable<T> TQuery()
        {
            return _db.AsQueryable();
        }


        public async Task<T> TGetById(int id)
        {
           return await _db.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id); 
        }

        public async Task<bool> TUpdate(T Entity)
        {
            _db.Update(Entity);
            await _context.SaveChangesAsync();
            return true;
        }

        //List<SelectListItem> cat = await _context.Categories.ToList();
    }
}

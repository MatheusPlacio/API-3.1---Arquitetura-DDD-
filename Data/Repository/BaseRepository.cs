using Data.Context;
using Domain.Entidades;
using Domain.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;
        public BaseRepository(MyContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
           var result = _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
           if (result == null)
            {
                return false;  
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _context.Set<T>().AnyAsync(x => x.Id == id);
        }


        public async Task<IEnumerable<T>> GetAsync()
        {
          return await _context.Set<T>().AsNoTracking().ToListAsync();
            
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> InsertAsync(T item)
        {
            if(item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }

            item.CreateAt = DateTime.UtcNow;
            _context.Set<T>().Add(item);

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == item.Id);
            if (result == null)
            {
                return null;
            }
            item.UpdateAt = DateTime.UtcNow;
            item.CreateAt = result.CreateAt;

            _context.Entry(result).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();

            return item;
        }
    }
}

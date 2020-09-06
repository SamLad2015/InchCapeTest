using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InchCapeTest.Entities;
using InchCapeTest.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InchCapeTest.Repositories
{
    public class ReadRepository<T>: IReadRepository<T> where T : BaseEntity
    {
        private readonly DbSet <T> _entities;  
        public ReadRepository(TestDbContext testDbContext)
        {
            _entities = testDbContext.Set <T> ();  
        }
        public async Task<IList<T>> GetAll(IList<string> includes = null)
        {
            IQueryable<T> query = _entities.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }
    }
}
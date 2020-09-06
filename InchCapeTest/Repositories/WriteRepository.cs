using System;
using InchCapeTest.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InchCapeTest.Repositories
{
    public class WriteRepository<T>: IWriteRepository<T> where T : class
    {
        private readonly DbSet <T> _entities;
        private readonly TestDbContext _testDbContext;
        public WriteRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
            _entities = _testDbContext.Set <T> ();  
        }
        public void Insert(T obj)
        {
            if (obj == null) {  
                throw new ArgumentNullException("entity");  
            }  
            _entities.Add(obj);  
            _testDbContext.SaveChanges(); 
        }
    }
}
using CleanArchtecture.Domain.Entities;
using CleanArchtecture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchtecture.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;
        public BaseRepository(AppDbContext context){
            Context = context;
        }
        public void Create(T entity){
            entity.DateCreated = DateTimeOffset.UtcNow;
            Context.Add(entity);
        }

        public void Update(T entitity){
            entity.DateCreated = DateTimeOffset.UtcNow;
            Context.Update(entitity);
        }
    }
}

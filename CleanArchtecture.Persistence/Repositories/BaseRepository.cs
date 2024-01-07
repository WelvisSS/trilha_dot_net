using CleanArchtecture.Domain.Entities;
using CleanArchtecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
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

        public void Delete(T entity){
            entity.DateDeleted = DateTimeOffset.UtcNow;
            Context.Remove(entity);
        }

        public async Task<T> Get(Guid id, CancellationToken cancellationToken){
            return await Context.Set<T>().FirstOrDefaultAsync(x=> x.Id == id, cancellationToken);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken){
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }
    }
}

using CleanArchtecture.Domain.Entities;
using CleanArchtecture.Domain.Interfaces;
using CleanArchtecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchtecture.Persistence.Repositories;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    { }

    public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}

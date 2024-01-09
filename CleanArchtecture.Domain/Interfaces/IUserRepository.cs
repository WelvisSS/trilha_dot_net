using CleanArchtecture.Domain.Entities;

namespace CleanArchtecture.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string email, CancellationToken cancellationToken);
}

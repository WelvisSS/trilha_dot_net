using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Domain.Interfaces;

public interface IUserRepository<T> where T : User
{
   Task<User> GetUsuarioNome(string Nome);
}

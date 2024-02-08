using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.ViewModels;
using ResTIConnect.Infrastructure.Persistence;

namespace ResTIConnect.Aplication;
public interface IUserService
{
     public List<UserViewModel> GetAll();
    public UserViewModel? GetById(int id);
    public int Create(NewUserInputModel user);
    public void Update(int id, NewUserInputModel user);
    public void Delete(int id);
}

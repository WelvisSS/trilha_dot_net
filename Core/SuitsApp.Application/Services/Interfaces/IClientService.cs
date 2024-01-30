using SuitsApp.Application.InputModels;
using SuitsApp.Application.ViewModels;

namespace SuitsApp.Application.Services.Interfaces;
public interface IClientService
{
    public List<ClientViewModel> GetAll();
    public ClientViewModel? GetById(int id);
    public int Create(NewClientInputModel client);
    public void Update(int id, NewClientInputModel client);
    public void Delete(int id);
    
}

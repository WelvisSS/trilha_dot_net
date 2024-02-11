using BarberApp.Application.InputModels;
using BarberApp.Application.ViewModels;
namespace BarberApp.Application.Services.Interfaces;

public interface IRequestService
{
    public List<RequestViewModel> GetAll();
    public RequestViewModel? GetById(int id);
    public int Create(NewRequestInputModel request);
    public void Update(int id, NewRequestInputModel request);
    public void Delete(int id);
}


using BarberApp.Application.InputModels;
using BarberApp.Application.ViewModels;
namespace BarberApp.Application.Services.Interfaces;

public interface IServiceService
{
    public List<ServiceViewModel> GetAll();
    public ServiceViewModel? GetById(int id);
    public List<ServiceViewModel> GetByEmployeeId(int id);
    public int Create(NewServiceInputModel service);
    public void Update(int id, NewServiceInputModel service);
    public void Delete(int id);
}


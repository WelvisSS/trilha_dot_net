using BarberApp.Application.InputModels;
using BarberApp.Application.ViewModels;

namespace BarberApp.Application.Services.Interfaces;

public interface IEmployeeService
{
    public List<EmployeeViewModel> GetAll();
    public EmployeeViewModel? GetById(int id);
    public int Create(NewEmployeeInputModel employee);
    public void Update(int id, NewEmployeeInputModel employee);
    public void Delete(int id);
}

using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.Interfaces;

public interface IExameService
{
    public List<ExameViewModel> GetAll();
    public ExameViewModel? GetById(int id);
    public int Create(NewExameInputModel exame);
    public void Update(int id, NewExameInputModel exame);
    public void Delete(int id);
}

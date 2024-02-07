using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.ViewModels;
namespace ResTIConnect.Aplication.Services.Interfaces;

public interface IPerfilService
{
    public List<PerfilViewModel> GetAll();
    public PerfilViewModel? GetById(int id);
    public int Create(NewPerfilInputModel medico);
    public void Update(int id, NewPerfilInputModel medico);
    public void Delete(int id);
}


using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.ViewModels;

namespace ResTIConnect.Aplication;

public interface ISistemaService
{
    public SistemaViewModel GetSistemaById(int id);
    public int CreateSistema(NewSistemaInputModel sistema);
    public int UpdateSistema(int id, NewSistemaInputModel sistema);
    public void DeleteSistema(int id);
    public List<SistemaViewModel> GetAllSistemas();
}

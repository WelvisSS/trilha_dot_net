using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.ViewModels;

namespace ResTIConnect.Aplication.Services.Interfaces;

public interface IEnderecoService
{
    public EnderecoViewModel GetEnderecoById(int id);
    public int CreateEndereco(NewEnderecoInputModel endereco);
    public int UpdateEndereco(int id, NewEnderecoInputModel endereco);
    public void DeleteEndereco(int id);
    public List<EnderecoViewModel> GetAllEnderecos();
}

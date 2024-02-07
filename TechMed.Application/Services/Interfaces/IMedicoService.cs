using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

namespace TechMed.Application.Services.Interfaces;

public interface IMedicoService
{
    public List<MedicoViewModel> GetAll();
    public MedicoViewModel? GetById(int id);
    public int Create(NewMedicoInputModel medico);
    public void Update(int id, NewMedicoInputModel medico);
    public void Delete(int id);
     public int CreateAtendimento(int medicoId,NewAtendimentoInputModel atendimento);
    void Update(MedicoViewModel medico);
}

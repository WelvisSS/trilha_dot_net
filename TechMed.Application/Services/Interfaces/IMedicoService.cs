namespace TechMed.Application.Interfaces;

public interface IMedicoService
{
    public List<MedicoViewModel> GetAll();
    public MedicoViewModel? GetById(int id);
    public int Create(NewMedicoInputModel medico);
    public void Update(int id, NewMedicoInputModel medico);
    public void Delete(int id);
}

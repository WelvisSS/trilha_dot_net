using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;

namespace TechMed.Application;

public interface IPacienteService
{
    public List<PacienteViewModel> GetAll();
    public PacienteViewModel? GetById(int id);
    public int Create(NewPacienteInputModel paciente);
    public void Update(int id, NewPacienteInputModel paciente);
    public void Delete(int id);
}

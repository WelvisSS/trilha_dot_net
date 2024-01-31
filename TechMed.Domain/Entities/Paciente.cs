namespace TechMed.Domain.Entities;
public class Paciente : Pessoa
{
    public int PacienteId { get; set; }
    public DateTime DataNascimento { get; set; }
}

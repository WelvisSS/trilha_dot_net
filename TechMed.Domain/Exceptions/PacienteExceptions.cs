namespace TechMed.Domain.Exceptions;

public class PacienteAlredyExistsException : Exception
{
    public PacienteAlredyExistsException():base("Paciente já existe!!"){}
}

public class PacienteNotFoundException : Exception{
    public PacienteNotFoundException():base("Paciente não encontrado!!"){}
}

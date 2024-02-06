namespace TechMed.Domain.Exceptions;

public class MedicoAlredyExistsException : Exception
{
    public MedicoAlredyExistsException():base("Medico já existe!!"){}
}

public class MedicoNotFoundException : Exception{
    public MedicoNotFoundException():base("Medico não encontrado!!"){}
}

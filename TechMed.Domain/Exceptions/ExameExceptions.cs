namespace TechMed.Domain.Exceptions;

public class ExameAlredyExistsException : Exception
{
    public ExameAlredyExistsException():base("Exame já existe!!"){}
}

public class ExameNotFoundException : Exception{
    public ExameNotFoundException():base("Exame não encontrado!!"){}
}

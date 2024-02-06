namespace TechMed.Domain.Exceptions;

public class AtendimentoAlredyExistsException : Exception
{
    public AtendimentoAlredyExistsException():base("Atendimento já existe!!"){}
}

public class AtendimentoNotFoundException : Exception{
    public AtendimentoNotFoundException():base("Atendimento não encontrado!!"){}
}

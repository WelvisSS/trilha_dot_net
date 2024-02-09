namespace BarberApp.Domain.Exceptions;

public class LegalPersonException
{
    public class LegalPersonNotFoundException : Exception
    {
        public LegalPersonNotFoundException() : base("Pessoa jurídica não encontrada") { }
    }

    public class LegalPersonAlreadyExistException : Exception
    {
        public LegalPersonAlreadyExistException() : base("Pessoa jurídica já cadastrada") { }
    }

    public class InvalidLegalPersonException : Exception
    {
        public InvalidLegalPersonException() : base("Informações invalidas") { }
    }
}

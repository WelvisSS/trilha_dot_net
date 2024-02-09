namespace BarberApp.Domain.Exceptions;

public class PersonException
{
    public class PersonNotFoundException : Exception
    {
        public PersonNotFoundException() : base("Pessoa não encontrada") { }
    }

    public class PersonAlreadyExistException : Exception
    {
        public PersonAlreadyExistException() : base("Pessoa ja foi feita") { }
    }

    public class InvalidPersonException : Exception
    {
        public InvalidPersonException() : base("Informações inválidas") { }
    }
}

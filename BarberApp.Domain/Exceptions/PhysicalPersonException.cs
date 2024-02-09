namespace BarberApp.Domain.Exceptions;

public class PhysicalPersonException
{
    public class PhysicalPersonNotFoundException : Exception
    {
        public PhysicalPersonNotFoundException() : base("Pessoa física não encontrada") { }
    }

    public class PhysicalPersonAlreadyExistException : Exception
    {
        public PhysicalPersonAlreadyExistException() : base("Pessoa física já cadastrada") { }
    }

    public class InvalidPhysicalPersonException : Exception
    {
        public InvalidPhysicalPersonException() : base("Informações invalidas") { }
    }
}

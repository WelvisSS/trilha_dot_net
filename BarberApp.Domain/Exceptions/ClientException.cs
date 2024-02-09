namespace BarberApp.Domain.Exceptions;

public class ClientException
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException() : base("Cliente não encontrado") { }
    }

    public class ClientAlreadyExistException : Exception
    {
        public ClientAlreadyExistException() : base("Cliente já cadastrado") { }
    }

    public class InvalidClientException : Exception
    {
        public InvalidClientException() : base("Informações invalidas") { }
    }
}

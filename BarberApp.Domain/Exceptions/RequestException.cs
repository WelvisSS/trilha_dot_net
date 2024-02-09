namespace BarberApp.Domain.Exceptions;

public class RequestException
{
    public class RequestNotFoundException : Exception
    {
        public RequestNotFoundException() : base("Requisição não encontrada") { }
    }

    public class RequestAlreadyExistException : Exception
    {
        public RequestAlreadyExistException() : base("Requisição ja foi feita") { }
    }

    public class InvalidRequestException : Exception
    {
        public InvalidRequestException() : base("Requisição invalida") { }
    }
}

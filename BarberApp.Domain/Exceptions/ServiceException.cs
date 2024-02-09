namespace BarberApp.Domain.Exceptions;

public class ServiceException
{
    public class ServiceNotFoundException : Exception
    {
        public ServiceNotFoundException() : base("Serviço não encontrado") { }
    }

    public class ServiceAlreadyExistException : Exception
    {
        public ServiceAlreadyExistException() : base("Serviço ja foi feito") { }
    }

    public class InvalidServiceException : Exception
    {
        public InvalidServiceException() : base("Serviço invalido") { }
    }
}

namespace BarberApp.Domain.Exceptions;

public class EmployeeException
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException() : base("Funcionário não encontrado") { }
    }

    public class EmployeeAlreadyExistException : Exception
    {
        public EmployeeAlreadyExistException() : base("Funcionário já cadastrado") { }
    }

    public class InvalidEmployeeException : Exception
    {
        public InvalidEmployeeException() : base("Informações invalidas") { }
    }
}

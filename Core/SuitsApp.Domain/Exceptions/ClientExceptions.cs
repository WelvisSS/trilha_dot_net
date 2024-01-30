namespace SuitsApp.Domain.Exceptions;
public class ClientAlreadyExistsExceptions : Exception
{
    public ClientAlreadyExistsExceptions(): 
        base("Client already exists"){}
}
public class ClientNotFoundException : Exception
{
    public ClientNotFoundException(): 
        base("Client not found"){}
}

namespace SuitsApp.Domain.Exceptions;
public class LawyerAlreadyExistsExceptions : Exception
{
    public LawyerAlreadyExistsExceptions(): 
        base("Lawyer already exists"){}
}
public class LawyerNotFoundException : Exception
{
    public LawyerNotFoundException(): 
        base("Lawyer not found"){}
}

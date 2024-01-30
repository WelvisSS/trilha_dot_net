namespace SuitsApp.Domain.Exceptions;
public class LegalCaseAlreadyExistsExceptions : Exception
{
    public LegalCaseAlreadyExistsExceptions(): 
        base("LegalCase already exists"){}
}
public class LegalCaseNotFoundException : Exception
{
    public LegalCaseNotFoundException(): 
        base("LegalCase not found"){}
}

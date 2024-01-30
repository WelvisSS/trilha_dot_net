namespace SuitsApp.Domain.Exceptions;
public class DocumentAlreadyExistsExceptions : Exception
{
    public DocumentAlreadyExistsExceptions(): 
        base("Document already exists"){}
}
public class DocumentNotFoundException : Exception
{
    public DocumentNotFoundException(): 
        base("Document not found"){}
}

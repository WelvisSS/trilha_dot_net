namespace BarberApp.Domain.Interfaces;

public interface IDatabaseFake
{
    public IRequestCollection RequestsCollection { get; }
    public IEmployeeCollection EmployeesCollection { get; }
}

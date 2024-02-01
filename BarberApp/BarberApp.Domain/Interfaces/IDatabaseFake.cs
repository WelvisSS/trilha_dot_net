namespace BarberApp.Domain.Interfaces;

public interface IDatabaseFake
{
    public IRequestCollection RequestsCollection { get; }
    public IEmployeeCollection EmployeesCollection { get; }
    public IClientCollection ClientsCollection { get; }
    public IServiceCollection ServicesCollection { get; }
    public IEstimateCollection EstimateCollection { get; }
}

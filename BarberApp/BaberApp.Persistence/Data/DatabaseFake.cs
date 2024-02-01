using BarberApp.Domain.Interfaces;
namespace BaberApp.Persistence.Data;
public class DatabaseFake : IDatabaseFake
{
    public IRequestCollection RequestsCollection { get; } = new RequestsDB();
    public IEmployeeCollection EmployeesCollection { get; } = new EmployeesDB();
    public IClientCollection ClientsCollection { get; } = new ClientDB();

    public IServiceCollection ServicesCollection { get; } = new ServicesDB();

}


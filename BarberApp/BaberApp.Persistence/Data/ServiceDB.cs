using BarberApp.Domain.Entities;
using BarberApp.Domain.Interfaces;
namespace BaberApp.Persistence.Data;

public class ServicesDB : IServiceCollection
{
    private readonly List<Service> _services = new List<Service>();
    private int _id = 0;
    public void Create(Service service)
    {
        if (_services.Count > 0)
            _id = _services.Max(m => m.ServiceId);
        service.ServiceId = ++_id;
        _services.Add(service);
    }
    public void Delete(int id)
    {
        _services.RemoveAll(m => m.ServiceId == id);
    }
    public ICollection<Service> GetAll()
    {
        return _services.ToArray();
    }
    public Service? GetById(int id)
    {
        return _services.FirstOrDefault(m => m.ServiceId == id);
    }
    public void Update(int id, Service service)
    {
        var serviceDB = _services.FirstOrDefault(m => m.ServiceId == id);
        if (serviceDB is not null)
        {
            //  requestDB.Nome = _services.Nome;
            serviceDB.ServiceType = service.ServiceType;
        }
    }
}

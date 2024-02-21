using BarberApp.Application.Services.Interfaces;
using BarberApp.Application.InputModels;
using BarberApp.Application.ViewModels;
using BarberApp.Domain.Entities;
using BarberApp.Domain.Exceptions;
using BarberApp.Infrastructure.Persistence.Context;


namespace BarberApp.Application.Services;

public class ServiceService : IServiceService
{
    public readonly BarberAppDbContext _context;

    public ServiceService(BarberAppDbContext context)
    {
        _context = context;
    }
    public Service GetByDbId(int id)
    {
        var _service = _context.Services.Find(id);
        if (_service == null) throw new ServiceException.ServiceNotFoundException();
        return _service;
    }
    public int Create(NewServiceInputModel service)
    {
        int id = 1;
        var _service = new Service
        {
            ServiceId = id++,
            RequestId = service.RequestId,
            EmployeeId = service.EmployeeId,
            ServiceType = service.ServiceType,
            Amount = service.Amount,
            Quantity = service.Quantity,
            Date = service.Date
        };

        _context.Services.Add(_service);
        _context.SaveChanges();
        return _service.ServiceId;
    }

    public void Delete(int id)
    {
        _context.Services.Remove(GetByDbId(id));
        _context.SaveChanges();
    }

    public List<ServiceViewModel> GetAll()
    {

        var _services = _context.Services.Select(m => new ServiceViewModel
        {
            ServiceType = m.ServiceType,
            Amount = m.Amount,
            Quantity = m.Quantity,
            Date = m.Date
        }).ToList();

        return _services;
    }

    public ServiceViewModel? GetById(int id)
    {
        var _service = GetByDbId(id);

        var ServiceViewModel = new ServiceViewModel
        {
            ServiceType = _service.ServiceType,
            Amount = _service.Amount,
            Quantity = _service.Quantity,
            Date = _service.Date
        };
        return ServiceViewModel;
    }

    public List<ServiceViewModel> GetByEmployeeId(int id)
    {
        var _services = _context.Services.Where(m => m.EmployeeId == id).Select(m => new ServiceViewModel
        {
            ServiceType = m.ServiceType,
            Amount = m.Amount,
            Quantity = m.Quantity,
            Date = m.Date
        }).ToList();

        return _services;
    }

    public void Update(int id, NewServiceInputModel service)
    {
        var _service = GetByDbId(id);

        _service.ServiceType = service.ServiceType;
        _service.Amount = service.Amount;
        _service.Quantity = service.Quantity;

        _context.Services.Update(_service);

        _context.SaveChanges();
    }
}

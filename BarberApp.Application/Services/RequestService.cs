using BarberApp.Application.Services.Interfaces;
using BarberApp.Application.InputModels;
using BarberApp.Application.ViewModels;
using BarberApp.Domain.Entities;
using BarberApp.Domain.Exceptions;
using static BarberApp.Domain.Exceptions.RequestException;
using BarberApp.Infrastructure.Persistence.Context;

namespace BarberApp.Application.Services;

public class RequestService : IRequestService
{
    public readonly BarberAppDbContext _context;

    public RequestService(BarberAppDbContext context)
    {
        _context = context;
    }
    public Request GetByDbId(int id)
    {
        var _request = _context.Requests.Find(id);
        if (_request == null) throw new RequestNotFoundException();
        return _request;
    }
    public int Create(NewRequestInputModel request)
    {
        var _request = new Request
        {
            RequestId = request.RequestId,
            ClientId = request.ClientId,
            Date = request.Date,
            RequiredAmount = request.RequiredAmount
        };

        _context.Requests.Add(_request);
        _context.SaveChanges();
        return _request.RequestId;
    }

    public void Delete(int id)
    {
        _context.Requests.Remove(GetByDbId(id));
        _context.SaveChanges();
    }

    public List<RequestViewModel> GetAll()
    {
        var _pacientes = _context.Requests.Select(m => new RequestViewModel
        {
            RequestId = m.RequestId,
            ClientId = m.ClientId,
            Date = m.Date,
            RequiredAmount = m.RequiredAmount

        }).ToList();

        return _pacientes;
    }

    public RequestViewModel? GetById(int id)
    {
        var _paciente = GetByDbId(id);

        var PacienteViewModel = new RequestViewModel
        {
            RequestId = _paciente.RequestId,
            ClientId = _paciente.ClientId,
            Date = _paciente.Date,
            RequiredAmount = _paciente.RequiredAmount
        };
        return PacienteViewModel;
    }

    public List<RequestViewModel> GetByClientId(int id)
    {
        var _requests = _context.Requests.Where(m => m.ClientId == id).Select(m => new RequestViewModel
        {
            RequestId = m.RequestId,
            ClientId = m.ClientId,
            Date = m.Date,
            RequiredAmount = m.RequiredAmount
        }).ToList();

        return _requests;
    }

    public void Update(int id, NewRequestInputModel paciente)
    {
        var _request = GetByDbId(id);

        _request.RequestId = paciente.RequestId;
        _request.ClientId = paciente.ClientId;
        _request.Date = paciente.Date;
        _request.RequiredAmount = paciente.RequiredAmount;

        _context.Requests.Update(_request);

        _context.SaveChanges();
    }
}

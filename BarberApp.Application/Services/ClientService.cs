using BarberApp.Application.InputModels;
using BarberApp.Application.Services.Interfaces;
using BarberApp.Application.ViewModels;
using BarberApp.Domain.Entities;
using BarberApp.Infrastructure.Auth;
using BarberApp.Infrastructure.Persistence.Context;
using static BarberApp.Domain.Exceptions.ClientException;

namespace BarberApp.Application.Services;

public class ClientService : IClientService
{
    public readonly BarberAppDbContext _context;

    private readonly IAuthService _authService;

    public ClientService(BarberAppDbContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public Client GetByDbId(int id)
    {
        var _client = _context.Clients.Find(id) ?? throw new ClientNotFoundException();
        return _client;
    }
    public int Create(NewClientInputModel client)
    {
        client.Password = _authService.ComputeSha256Hash(client.Password);
        var _client = new Client
        {
            PersonId = client.PersonId,
            Name = client.Name,
            Email = client.Email,
            Password = client.Password,
            Role = client.Role,
            CEP = client.CEP,
        };

        _context.Clients.Add(_client);
        _context.SaveChanges();
        return _client.ClientId;
    }

    public void Delete(int id)
    {
        _context.Clients.Remove(GetByDbId(id));
        _context.SaveChanges();
    }

    public List<ClientViewModel> GetAll()
    {
        var _clients = _context.Clients.Select(m => new ClientViewModel
        {
            Name = m.Name,
            ClientId = m.ClientId,
            PersonId = m.PersonId,
            Email = m.Email,
            CEP = m.CEP,

        }).ToList();

        return _clients;
    }

    public ClientViewModel? GetById(int id)
    {
        var _client = GetByDbId(id);
        return new ClientViewModel
        {
            ClientId = _client.ClientId,
            PersonId = _client.PersonId,
            Name = _client.Name,
            Email = _client.Email,
            CEP = _client.CEP,
        };
    }

    public void Update(int id, NewClientInputModel client)
    {
        var _client = GetByDbId(id);

        _client.Name = client.Name;
        _client.Email = client.Email;
        _client.CEP = client.CEP;

        _context.Clients.Update(_client);

        _context.SaveChanges();
    }
}

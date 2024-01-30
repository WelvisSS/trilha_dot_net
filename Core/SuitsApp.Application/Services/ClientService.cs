using SuitsApp.Application.InputModels;
using SuitsApp.Application.Services.Interfaces;
using SuitsApp.Application.ViewModels;
using SuitsApp.Domain.Entities;
using SuitsApp.Domain.Exceptions;
using SuitsApp.Infra.Persistence;

namespace SuitsApp.Application.Services;
public class ClientService : IClientService
{
    private readonly SuisAppDbContext _context;
    public ClientService(SuisAppDbContext context){
        _context = context;
    }

     public Client GetByDbId(int id)
    {
        var _client = _context.Clients.Find(id);
        if (_client == null)
            throw new ClientNotFoundException();
        return _client;
    }

    public int Create(NewClientInputModel client)
    {
        var _client = new Client
        {
            Name = client.Name,
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
        var _clients = _context.Clients.Select(m => new ClientViewModel{
            ClientId = m.ClientId,
            Name = m.Name
        }).ToList();

        return _clients;
    }

    public ClientViewModel? GetById(int id)
    {
        var _client = GetByDbId(id);
        var ClientViewModel = new ClientViewModel{
            ClientId = _client.ClientId,
            Name = _client.Name
        };
        return ClientViewModel;
    }
   
    public void Update(int id, NewClientInputModel client)
    {
        var _client = GetByDbId(id);
        _client.Name = client.Name;
        _context.Clients.Update(_client);
        _context.SaveChanges();
    }
}

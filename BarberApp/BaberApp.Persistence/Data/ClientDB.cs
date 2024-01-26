using BarberApp.Domain.Entities;
using BarberApp.Domain.Interfaces;

namespace BaberApp.Persistence.Data;

public class ClientDB : IClientCollection
{
    private readonly List<Client> _clients = new List<Client>();
    private int _id = 0;
    public void Create(Client client)
    {
        if (_clients.Count > 0)
            _id = _clients.Max(m => m.ClientId);
        client.ClientId = ++_id;
        client.PersonId = ++_id;
        LegalPerson legalPerson = new LegalPerson
        {
            PersonId = client.PersonId,
            CNPJ = "11111111111111",
        };
         PhysicalPerson physicalPerson = new PhysicalPerson
        {
            PersonId = client.PersonId,
            CPF = "00000000000000",
        };
        _clients.Add(client);
    }

    public void Delete(int id)
    {
        _clients.RemoveAll(m => m.ClientId == id);
    }

    public ICollection<Client> GetAll()
    {
        return _clients.ToArray();
    }

    public Client? GetById(int id)
    {
        return _clients.FirstOrDefault(m => m.ClientId == id);
    }

    public void Update(int id, Client client)
    {
        var clientDB = _clients.FirstOrDefault(m => m.ClientId == id);
        if (clientDB is not null)
        {
            clientDB.Name = client.Name;
            clientDB.Email = client.Email;
        }
    }
}

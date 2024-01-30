using SuitsApp.Domain.Entities;
using SuitsApp.Infra.Persistence.Interfaces;

namespace SuitsApp.Infra.Persistence;
public class ClientDb : IClientCollection
{
    private readonly List<Client> _clients = new List<Client>();
    private int _id = 2;
    public int Create(Client client)
    {
        if(_clients.Count > 0)
          _id = _clients.Max(x => x.ClientId);
          client.ClientId = ++_id;
        _clients.Add(client);
        return client.ClientId;
    }

    public void Delete(int id)
    {
        _clients.RemoveAll(x => x.ClientId == id);
    }

    public ICollection<Client> GetAll()
    {
        return _clients.ToArray();
    }

    public Client? GetById(int id)
    {
        return _clients.FirstOrDefault(x => x.ClientId == id);
    }

    public void Update(int id, Client client)
    {
        var clientdb = _clients.FirstOrDefault(x => x.ClientId == id);
        if(clientdb != null){
            clientdb.Name = client.Name;
        }
    }
}

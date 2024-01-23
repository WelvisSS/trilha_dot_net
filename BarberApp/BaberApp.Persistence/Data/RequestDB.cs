using BarberApp.Domain.Entities;
using BarberApp.Domain.Interfaces;
namespace BaberApp.Persistence.Data;

public class RequestsDB : IRequestCollection
{
    private readonly List<Request> _requests = new List<Request>();
    private int _id = 0;
    public void Create(Request request)
    {
        if (_requests.Count > 0)
            _id = _requests.Max(m => m.RequestId);
        request.RequestId = ++_id;
        _requests.Add(request);
    }
    public void Delete(int id)
    {
        _requests.RemoveAll(m => m.RequestId == id);
    }
    public ICollection<Request> GetAll()
    {
        return _requests.ToArray();
    }
    public Request? GetById(int id)
    {
        return _requests.FirstOrDefault(m => m.RequestId == id);
    }
    public void Update(int id, Request request)
    {
        var requestDB = _requests.FirstOrDefault(m => m.RequestId == id);
        if (requestDB is not null)
        {
            //  requestDB.Nome = _requests.Nome;
        }
    }
}

using BarberApp.Domain.Entities;
using BarberApp.Domain.Interfaces;
namespace BaberApp.Persistence.Data;

public class EstimateDB : IEstimateCollection
{
    private readonly List<Estimate> _estimate = new List<Estimate>();
    private int _id = 0;
    public void Create(Estimate estimate)
    {
        if (_estimate.Count > 0)
            _id = _estimate.Max(m => m.EstimateId);
        estimate.EstimateId = ++_id;
        _estimate.Add(estimate);
    }
    public void Delete(int id)
    {
        _estimate.RemoveAll(m => m.EstimateId == id);
    }
    public ICollection<Estimate> GetAll()
    {
        return _estimate.ToArray();
    }
    public Estimate? GetById(int id)
    {
        return _estimate.FirstOrDefault(m => m.EstimateId == id);
    }
    public void Update(int id, Estimate estimate)
    {
        var estimateDB = _estimate.FirstOrDefault(m => m.EstimateId == id);
        if (estimateDB is not null)
        {
            //  estimateDB.Nome = _estimate.Nome;
        }
    }
}

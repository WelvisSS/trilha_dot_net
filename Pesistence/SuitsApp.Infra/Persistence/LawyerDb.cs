using SuitsApp.Domain.Entities;
using SuitsApp.Infra.Persistence.Interfaces;

namespace SuitsApp.Infra.Persistence;
public class LawyerDb : ILawyerCollection
{
    private readonly List<Lawyer> _lawyers = new List<Lawyer>();
    private int _id = 2;
    public int Create(Lawyer Lawyer)
    {
        if(_lawyers.Count > 0)
          _id = _lawyers.Max(x => x.LawyerId);
          Lawyer.LawyerId = ++_id;
        _lawyers.Add(Lawyer);
        return Lawyer.LawyerId;
    }

    public void Delete(int id)
    {
        _lawyers.RemoveAll(x => x.LawyerId == id);
    }

    public ICollection<Lawyer> GetAll()
    {
        return _lawyers.ToArray();
    }

    public Lawyer? GetById(int id)
    {
        return _lawyers.FirstOrDefault(x => x.LawyerId == id);
    }

    public void Update(int id, Lawyer Lawyer)
    {
        var Lawyerdb = _lawyers.FirstOrDefault(x => x.LawyerId == id);
        if(Lawyerdb != null){
            Lawyerdb.Name = Lawyer.Name;
        }
    }
}

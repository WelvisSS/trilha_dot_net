using SuitsApp.Domain.Entities;
using SuitsApp.Infra.Persistence.Interfaces;

namespace SuitsApp.Infra.Persistence;
public class LegalCaseDb : ILegalCaseCollection
{
    private readonly List<LegalCase> _legalCases = new List<LegalCase>();
    private int _id = 2;
    public int Create(LegalCase LegalCase)
    {
        if(_legalCases.Count > 0)
          _id = _legalCases.Max(x => x.LegalCaseId);
          LegalCase.LegalCaseId = ++_id;
        _legalCases.Add(LegalCase);
        return LegalCase.LegalCaseId;
    }

    public void Delete(int id)
    {
        _legalCases.RemoveAll(x => x.LegalCaseId == id);
    }

    public ICollection<LegalCase> GetAll()
    {
        return _legalCases.ToArray();
    }

    public LegalCase? GetById(int id)
    {
        return _legalCases.FirstOrDefault(x => x.LegalCaseId == id);
    }

    public void Update(int id, LegalCase LegalCase)
    {
        var LegalCasedb = _legalCases.FirstOrDefault(x => x.LegalCaseId == id);
        if(LegalCasedb != null){
            LegalCasedb.Status = LegalCase.Status;
        }
    }
}

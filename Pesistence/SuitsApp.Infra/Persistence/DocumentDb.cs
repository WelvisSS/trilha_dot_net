using SuitsApp.Domain.Entities;
using SuitsApp.Infra.Persistence.Interfaces;

namespace SuitsApp.Infra.Persistence;
public class DocumentDb : IDocumentCollection
{
    private readonly List<Document> _documents = new List<Document>();
    private int _id = 2;
    public int Create(Document document)
    {
        if(_documents.Count > 0)
          _id = _documents.Max(x => x.DocumentId);
          document.DocumentId = ++_id;
        _documents.Add(document);
        return document.DocumentId;
    }

    public void Delete(int id)
    {
        _documents.RemoveAll(x => x.DocumentId == id);
    }

    public ICollection<Document> GetAll()
    {
        return _documents.ToArray();
    }

    public Document? GetById(int id)
    {
        return _documents.FirstOrDefault(x => x.DocumentId == id);
    }

    public void Update(int id, Document document)
    {
        var documentdb = _documents.FirstOrDefault(x => x.DocumentId == id);
        if(documentdb != null){
            documentdb.Description = document.Description;
        }
    }
}

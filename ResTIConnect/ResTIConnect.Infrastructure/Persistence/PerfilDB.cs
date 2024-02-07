using ResTIConnect.Domain.Entities;
namespace ResTIConnect.Infrastructure;

public class PerfilDB : IPerfilCollection
{
    private readonly List<Perfis> _perfis = new List<Perfis>();
    private int _id = 2;
    public PerfilDB()
    {
        _perfis.Add(new Perfis { PerfilId = 1, Descricao = "Descrição 1", Permissoes = "1,2,3,4,5" });
        _perfis.Add(new Perfis { PerfilId = 2, Descricao = "Descrição 2", Permissoes = "7,8,9,10,11" });
    }
    public int Create(Perfis perfil)
    {
        if (_perfis.Count > 0)
            _id = _perfis.Max(m => m.PerfilId);
        perfil.PerfilId = ++_id;
        _perfis.Add(perfil);
        return perfil.PerfilId;
    }
    public void Delete(int id)
    {
        _perfis.RemoveAll(m => m.PerfilId == id);
    }
    public ICollection<Perfis> GetAll()
    {
        return _perfis.ToArray();
    }
    public Perfis? GetById(int id)
    {
        return _perfis.FirstOrDefault(m => m.PerfilId == id);
    }
    public void Update(int id, Perfis perfil)
    {
        var perfilDB = _perfis.FirstOrDefault(m => m.PerfilId == id);
        if (perfilDB is not null)
        {
            perfilDB.Descricao = perfil.Descricao;
        }
    }
}

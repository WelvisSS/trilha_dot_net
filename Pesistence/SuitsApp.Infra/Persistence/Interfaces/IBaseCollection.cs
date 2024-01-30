namespace SuitsApp.Infra.Persistence.Interfaces;
public interface IBaseCollection<T>
{
    int Create(T entity);
    ICollection<T> GetAll();
    T? GetById(int id);
    void Update(int id, T entity);
    void Delete(int id);
}

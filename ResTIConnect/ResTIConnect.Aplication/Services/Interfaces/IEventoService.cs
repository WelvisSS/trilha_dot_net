using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.ViewModels;

namespace ResTIConnect.Aplication.Services.Interfaces;

public interface IEventoService
{
    public List<EventoViewModel> GetAll();
    public EventoViewModel? GetById(int id);
    public int Create(NewEventoInputModel evento);
    public void Update(int id, NewEventoInputModel evento);
    public void Delete(int id);
}

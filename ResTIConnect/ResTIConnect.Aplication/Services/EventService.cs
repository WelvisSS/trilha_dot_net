using System.Data.Common;
using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.Services.Interfaces;
using ResTIConnect.Aplication.ViewModels;
using ResTIConnect.Domain;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infrastructure.Persistence;

namespace ResTIConnect.Aplication.Services;

public class EventoService : IEventoService 
{
    private readonly ResTIConnectDbContext _context;
    public EventoService(ResTIConnectDbContext context)
    {
        _context = context;
    }

    private Eventos GetByDbId(int id)
    {
        var _evento = _context.Eventos.Find(id);

        if (_evento is null)
            throw new PerfilNotFoundException();

        return _evento;
    }

    public int Create(NewEventoInputModel evento)
    {
        int id = 1;
        var _evento = new Eventos
        {
            EventoId = id++,
            Tipo = evento.Tipo,
            Descricao = evento.Descricao,
            Codigo = evento.Codigo,
            Conteudo = evento.Conteudo,
            DataHoraOcorrencia = evento.DataHoraOcorrencia
        
        };
        _context.Eventos.Add(_evento);

        _context.SaveChanges();

        return _evento.EventoId;
    }

    public void Delete(int id)
    {
        _context.Eventos.Remove(GetByDbId(id));

        _context.SaveChanges();
    }

    public List<EventoViewModel> GetAll()
    {
        var _eventos = _context.Eventos.Select(m => new EventoViewModel
        {
            Tipo = m.Tipo,
            Descricao = m.Descricao,
            Codigo = m.Codigo,
            Conteudo = m.Conteudo,
            DataHoraOcorrencia = m.DataHoraOcorrencia
        
        }).ToList();

        return _eventos;
    }

    public EventoViewModel? GetById(int id)
    {
        var _evento = GetByDbId(id);

        var EventoViewModel = new EventoViewModel
        {
            Tipo = _evento.Tipo,
            Descricao = _evento.Descricao,
            Codigo = _evento.Codigo,
            Conteudo = _evento.Conteudo,
            DataHoraOcorrencia = _evento.DataHoraOcorrencia
        };
        return EventoViewModel;
    }

    public void Update(int id, NewEventoInputModel evento)
    {
        var _evento = GetByDbId(id);

        _evento.Tipo = evento.Tipo;
        _evento.Descricao = evento.Descricao;
        _evento.Conteudo = evento.Conteudo;
        

        _context.Eventos.Update(_evento);

        _context.SaveChanges();
    }
}


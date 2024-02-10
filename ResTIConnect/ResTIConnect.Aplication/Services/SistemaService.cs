using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infrastructure.Persistence;
using static ResTIConnect.Domain.Exceptions.SistemasException;

namespace ResTIConnect.Aplication.Services;

public class SistemaService : ISistemaService
{
    private readonly ResTIConnectDbContext _context;
    public SistemaService(ResTIConnectDbContext context)
    {
        _context = context;
    }

    private Sistemas GetByDbId(int id)
    {
        var _sistema = _context.Sistemas.Find(id);

        if (_sistema is null)
            throw new SistemaNaoEncontradoException();

        return _sistema;
    }

    public int CreateSistema(NewSistemaInputModel sistema)
    {
        var _sistema = new Sistemas
        {
            Descricao = sistema.Descricao,
            Tipo = sistema.Tipo,
            EnderecoEntrada = sistema.EnderecoEntrada,
            EnderecoSaida = sistema.EnderecoSaida,
            Protocolo = sistema.Protocolo,
            DataHoraOcorrencia = sistema.DataHoraOcorrencia,
            Status = sistema.Status,
        };
        _context.Sistemas.Add(_sistema);
        _context.SaveChanges();
        return _sistema.SistemaId;
    }

    public void DeleteSistema(int id)
    {
        var _sistema = GetByDbId(id);
        _context.Sistemas.Remove(_sistema);
        _context.SaveChanges();
    }

    public List<SistemaViewModel> GetAllSistemas()
    {
        var _sistemas = _context.Sistemas.Select(s => new SistemaViewModel
        {
            Descricao = s.Descricao,
            Tipo = s.Tipo,
            EnderecoEntrada = s.EnderecoEntrada,
            EnderecoSaida = s.EnderecoSaida,
            Protocolo = s.Protocolo,
            DataHoraOcorrencia = s.DataHoraOcorrencia,
            Status = s.Status,
        }).ToList();
        return _sistemas;
    }

    public SistemaViewModel GetSistemaById(int id)
    {
        var _sistema = GetByDbId(id);
        return new SistemaViewModel
        {
            Descricao = _sistema.Descricao,
            Tipo = _sistema.Tipo,
            EnderecoEntrada = _sistema.EnderecoEntrada,
            EnderecoSaida = _sistema.EnderecoSaida,
            Protocolo = _sistema.Protocolo,
            DataHoraOcorrencia = _sistema.DataHoraOcorrencia,
            Status = _sistema.Status,
        };
    }

    public int UpdateSistema(int id, NewSistemaInputModel sistema)
    {
        var _sistema = GetByDbId(id);
        _sistema.Descricao = sistema.Descricao;
        _sistema.Tipo = sistema.Tipo;
        _sistema.EnderecoEntrada = sistema.EnderecoEntrada;
        _sistema.EnderecoSaida = sistema.EnderecoSaida;
        _sistema.Protocolo = sistema.Protocolo;
        _sistema.DataHoraOcorrencia = sistema.DataHoraOcorrencia;
        _sistema.Status = sistema.Status;
        _context.SaveChanges();
        return _sistema.SistemaId;
    }
}

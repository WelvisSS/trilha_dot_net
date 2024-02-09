using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.Services.Interfaces;
using ResTIConnect.Aplication.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infrastructure.Persistence;
using static ResTIConnect.Domain.Exceptions.EnderecoException;

namespace ResTIConnect.Aplication;

public class EnderecoService : IEnderecoService
{
    private readonly ResTIConnectDbContext _context;
    public EnderecoService(ResTIConnectDbContext context)
    {
        _context = context;
    }



    private Enderecos GetByDbId(int id)
    {
        var _endereco = _context.Enderecos.Find(id);

        if (_endereco is null)
            throw new EnderecoNaoEncontradoException();

        return _endereco;
    }
    public int CreateEndereco(NewEnderecoInputModel endereco)
    {
        var _endereco = new Enderecos
        {
            Logradouro = endereco.Logradouro,
            Complemento = endereco.Complemento,
            Bairro = endereco.Bairro,
            Estado = endereco.Estado,
            Pais = endereco.Pais,
            Numero = endereco.Numero,
            Cidade = endereco.Cidade,
            Cep = endereco.Cep
        };
        _context.Enderecos.Add(_endereco);
        _context.SaveChanges();
        return _endereco.EnderecoId;
    }

    public void DeleteEndereco(int id)
    {
        var _endereco = GetByDbId(id);
        _context.Enderecos.Remove(_endereco);
        _context.SaveChanges();
    }

    public List<EnderecoViewModel> GetAllEnderecos()
    {
        var _enderecos = _context.Enderecos.Select(e => new EnderecoViewModel
        {
            Logradouro = e.Logradouro,
            Complemento = e.Complemento,
            Bairro = e.Bairro,
            Estado = e.Estado,
            Pais = e.Pais,
            Numero = e.Numero,
            Cidade = e.Cidade
        }).ToList();
        return _enderecos;
    }

    public EnderecoViewModel GetEnderecoById(int id)
    {
        var _endereco = GetByDbId(id);
        return new EnderecoViewModel
        {
            Logradouro = _endereco.Logradouro,
            Complemento = _endereco.Complemento,
            Bairro = _endereco.Bairro,
            Estado = _endereco.Estado,
            Pais = _endereco.Pais,
            Numero = _endereco.Numero,
            Cidade = _endereco.Cidade
        };
    }

    public int UpdateEndereco(int id, NewEnderecoInputModel endereco)
    {
        var _endereco = GetByDbId(id);
        _endereco.Logradouro = endereco.Logradouro;
        _endereco.Complemento = endereco.Complemento;
        _endereco.Bairro = endereco.Bairro;
        _endereco.Estado = endereco.Estado;
        _endereco.Pais = endereco.Pais;
        _endereco.Numero = endereco.Numero;
        _endereco.Cidade = endereco.Cidade;
        _endereco.Cep = endereco.Cep;
        _context.SaveChanges();
        return _endereco.EnderecoId;
    }
}

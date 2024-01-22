using ResTIConnect.Domain.Entities;
using ResTIConnect.Infrastructure.Context;

var context = new ResTIConnectContext();

context.Perfis.RemoveRange(context.Perfis);
context.Enderecos.RemoveRange(context.Enderecos);
context.Users.RemoveRange(context.Users);
context.Logs.RemoveRange(context.Logs);
context.Eventos.RemoveRange(context.Eventos);

context.SaveChanges();

Console.WriteLine($"Criar um endereço no banco de dados");

var endereco01 = new Enderecos{
    Logradouro = "Travessa Garcia",
    Numero = "51",
    Cidade = "Itabuna",
    Cep = "45600295",
    Bairro = "Centro",
    Estado = "Bahia",
    Pais = "Brazil",
};
context.Enderecos.Add(endereco01);

var endereco02 = new Enderecos{
  Logradouro = "Rua José Bonifácio",
  Numero = "100",
  Cidade = "Salvador",
  Cep = "40290-000",
  Bairro = "Canela",
  Estado = "Bahia",
  Pais = "Brazil",
};

context.Enderecos.Add(endereco02);

var endereco03 = new Enderecos{
  Logradouro = "Avenida Sete de Setembro",
  Numero = "1234",
  Cidade = "Rio de Janeiro",
  Cep = "20021-000",
  Bairro = "Centro",
  Estado = "Rio de Janeiro",
  Pais = "Brazil",
};

context.Enderecos.Add(endereco03);

var endereco04 = new Enderecos{
  Logradouro = "Rua Paulista",
  Numero = "5678",
  Cidade = "São Paulo",
  Cep = "01310-000",
  Bairro = "Bela Vista",
  Estado = "São Paulo",
  Pais = "Brazil",
};

context.Enderecos.Add(endereco04);

var endereco05 = new Enderecos{
  Logradouro = "Rua Joaquim Nabuco",
  Numero = "9012",
  Cidade = "Belo Horizonte",
  Cep = "30160-000",
  Bairro = "Savassi",
  Estado = "Minas Gerais",
  Pais = "Brazil",
};

context.Enderecos.Add(endereco05);

context.SaveChanges();

Console.WriteLine($"Criar um usuario no banco de dados");

var usuario01 = new User{
    Nome = "Eduardo",
    Apelido = "Zacarias",
    Email = "eduardo@gmail.com",
    Senha = "123456",
    Telefone = "992734457",
    Endereco = endereco01,
};
context.Users.Add(usuario01);

context.SaveChanges();

Console.WriteLine($"Criar um perfil no banco de dados");

var perfil01 = new Perfis{
    Descricao = "Estudando de CIC da Uesc",
    Permissoes = "Estudar calado",
    User = usuario01,
};

context.Perfis.Add(perfil01);

context.SaveChanges();

// var perfil02 = new Perfis{
//   Descricao = "Professor de CIC da Uesc",
//   Permissoes = "Dar aula, corrigir provas, participar de bancas",
// };

// context.Perfis.Add(perfil02);

// var perfil03 = new Perfis{
//   Descricao = "Funcionário administrativo da Uesc",
//   Permissoes = "Realizar matrículas, emitir boletos, atender alunos",
// };

// context.Perfis.Add(perfil03);

// var perfil04 = new Perfis{
//   Descricao = "Estudante de outra instituição",
//   Permissoes = "Visitar a biblioteca, participar de eventos",
// };

// context.Perfis.Add(perfil04);

// var perfil05 = new Perfis{
//   Descricao = "Pessoa da comunidade",
//   Permissoes = "Acessar o museu, participar de palestras",
// };

// context.Perfis.Add(perfil05);

context.SaveChanges();

Console.WriteLine($"Criar um evento no banco de dados");

var evento01 = new Eventos{
    Tipo = "Festa",
    Descricao = "Festa de formatura de Eduardo",
    Codigo = "01",
    Conteudo = "Festa de fomatura",
    DataHoraOcorrencia = DateTimeOffset.Parse("30/01/2024 19:00"),
};

var evento02 = new Eventos{
    Tipo = "Reuniao",
    Descricao = "Reuniao para inicio do projeto",
    Codigo = "02",
    Conteudo = "Definir metas e dividir atividades",
    DataHoraOcorrencia = DateTimeOffset.Parse("25/01/2024 09:00"),
};

context.SaveChanges();


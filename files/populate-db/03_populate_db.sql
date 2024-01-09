-- Inserção de dados em Pessoa
INSERT INTO Pessoa (cod_pessoa) VALUES (1);
INSERT INTO Pessoa (cod_pessoa) VALUES (2);
INSERT INTO Pessoa (cod_pessoa) VALUES (3);
INSERT INTO Pessoa (cod_pessoa) VALUES (4);
INSERT INTO Pessoa (cod_pessoa) VALUES (5);

-- Inserção de dados em Pessoa_Fisica
INSERT INTO Pessoa_Fisica (cod_pessoa, cpf) VALUES (1, '111.111.111-11');
INSERT INTO Pessoa_Fisica (cod_pessoa, cpf) VALUES (2, '222.222.222-22');
INSERT INTO Pessoa_Fisica (cod_pessoa, cpf) VALUES (3, '333.333.333-33');

-- Inserção de dados em Pessoa_Juridica
INSERT INTO Pessoa_Juridica (cod_pessoa, cnpj) VALUES (1, '11.111.111/0001-01');
INSERT INTO Pessoa_Juridica (cod_pessoa, cnpj) VALUES (2, '22.222.222/0001-02');
INSERT INTO Pessoa_Juridica (cod_pessoa, cnpj) VALUES (3, '33.333.333/0001-03');

-- Inserção de dados em Clientes
INSERT INTO Clientes (cod_cliente, cod_pessoa, nome) VALUES (1, 1, 'Cliente 1');
INSERT INTO Clientes (cod_cliente, cod_pessoa, nome) VALUES (2, 2, 'Cliente 2');
INSERT INTO Clientes (cod_cliente, cod_pessoa, nome) VALUES (3, 3, 'Cliente 3');

-- Inserção de dados em Solicitacoes
INSERT INTO Solicitacoes (cod_solicitacao, cod_cliente, timestamp, valor_solicitado, Solicitacoescol) VALUES 
    (1, 1, '2023-01-01 10:00:00', 100.00, 'Solicitacao 1');
INSERT INTO Solicitacoes (cod_solicitacao, cod_cliente, timestamp, valor_solicitado, Solicitacoescol) VALUES 
    (2, 2, '2023-02-01 12:30:00', 150.00, 'Solicitacao 2');
INSERT INTO Solicitacoes (cod_solicitacao, cod_cliente, timestamp, valor_solicitado, Solicitacoescol) VALUES 
    (3, 3, '2023-03-01 15:45:00', 200.00, 'Solicitacao 3');

-- Inserção de dados em Funcionario
INSERT INTO Funcionario (cod_funcionario, cod_pessoa, nome, telefone) VALUES (1, 4, 'Funcionario 1', '111-1111');
INSERT INTO Funcionario (cod_funcionario, cod_pessoa, nome, telefone) VALUES (2, 5, 'Funcionario 2', '222-2222');

-- Inserção de dados em Servico
INSERT INTO Servico (cod_servico, cod_solicitacao, cod_funcionario, tipo, valor, quantidade, timestamp) VALUES 
    (1, 1, 1, 'Tipo A', 50.00, 2, '2023-01-02 11:00:00');
INSERT INTO Servico (cod_servico, cod_solicitacao, cod_funcionario, tipo, valor, quantidade, timestamp) VALUES 
    (2, 2, 2, 'Tipo B', 75.00, 3, '2023-02-02 13:45:00');
INSERT INTO Servico (cod_servico, cod_solicitacao, cod_funcionario, tipo, valor, quantidade, timestamp) VALUES 
    (3, 3, 1, 'Tipo C', 100.00, 1, '2023-03-02 16:30:00');

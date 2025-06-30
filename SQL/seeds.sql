-- Inserção de Filial Central
INSERT INTO Filiais (Nome, Endereco, CustoOperacional, Faturamento)
VALUES ('Filial Central', 'Rua Principal, 123 - Centro', 10000.00, 0.00);

-- Inserção de Setores
INSERT INTO Setores (Nome) VALUES ('Gerência');
INSERT INTO Setores (Nome) VALUES ('Atendimento');
INSERT INTO Setores (Nome) VALUES ('Estoquista');
INSERT INTO Setores (Nome) VALUES ('Serviços Gerais');
INSERT INTO Setores (Nome) VALUES ('Administrador');

-- Inserção de Funcionário de teste
INSERT INTO Funcionarios (
    Nome, Sexo, UsuarioId, DataAniversario, Salario, DiasTrabalhados,
    FaltasNaoJustificadas, NivelAcesso, FilialId, SetorId
)
VALUES (
    'João Silva', 'M', 'joaosilva01', '1990-05-20', 3200.00, 20, 0,
    'Administrador',
    1, -- Filial Central
    5  -- Setor Administrador
);

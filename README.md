/LocadoraFilmes/                ← Pasta raiz do projeto
├── LocadoraFilmes.csproj       ← Arquivo do projeto .NET
├── README.md                   ← Documentação geral do projeto

├── App.axaml                   ← Arquivo principal Avalonia (UI)
├── App.axaml.cs                ← Code-behind do App.axaml
├── MainWindow.axaml            ← Tela principal Avalonia
├── MainWindow.axaml.cs         ← Code-behind da tela principal

├── Models/                     ← Modelos de dados (entidades do banco)
│   ├── Funcionario.cs
│   ├── Filme.cs
│   ├── Cliente.cs
│   ├── Aluguel.cs
│   ├── Filial.cs
│   ├── Setor.cs
│   ├── AvaliacaoFilme.cs
│   └── MovimentacaoEstoque.cs

├── ViewModels/                 ← Classes de lógica das telas (MVVM)
│   ├── LoginViewModel.cs
│   ├── FilmesViewModel.cs
│   ├── FuncionariosViewModel.cs
│   └── (Outros ViewModels)

├── Views/                      ← Telas Avalonia (XAML)
│   ├── LoginView.axaml
│   ├── FilmesView.axaml
│   ├── FuncionariosView.axaml
│   └── (Outras Views)

├── Services/                   ← Lógica de negócios e acesso a dados
│   ├── FilmeService.cs
│   ├── FuncionarioService.cs
│   ├── AluguelService.cs
│   └── (Outros Services)

├── Data/                       ← Configuração do banco e migrations
│   ├── LocadoraDbContext.cs
│   └── Migrations/             ← Migrations geradas pelo EF Core

├── SQL/                        ← Scripts SQL para funções, procedures, triggers
│   ├── functions.sql
│   ├── procedures.sql
│   ├── triggers.sql
│   └── seeds.sql               ← Dados iniciais (ex: filial central, setores)

├── Resources/                  ← Ícones, fontes, arquivos estáticos
│   └── icons/

├── Utils/                      ← Funções utilitárias e helpers
│   ├── HashHelper.cs
│   └── SessionManager.cs

apenas um exemplo feito pelo gpt, logicamente não vamos fazer tudo isso em menos de 1 semana

🗓️ Objetivo

Desenvolver uma estrutura básica de banco de dados para uma locadora de filmes, incluindo cadastro de filiais, funcionários, filmes, clientes e controle de aluguéis, com funcionalidades essenciais para demonstração em 1 semana.
📂 Estrutura do Projeto

    Models/ — Entidades representando tabelas do banco (Filial, Funcionario, Filme, Cliente, Aluguel, Setor, AvaliacaoFilme)

    Data/ — Contexto do Entity Framework Core e migrations para criação do banco

    SQL/ — Scripts SQL com procedures, triggers e funções para automatizar operações

    Program.cs — Aplicação console para demonstração do CRUD básico (ex: gerenciamento de filiais)

    Views/ e ViewModels/ — Telas e lógica para futura interface Avalonia (não implementadas nesta demo)

🚀 Como executar
Pré-requisitos

    .NET 7 SDK

    SQLite (opcional, para inspecionar banco)

    IDE (Visual Studio, VS Code, Rider ou similar)

Passos

    Clone o repositório

    Abra o terminal na pasta do projeto

    Rode as migrations para criar o banco:

dotnet ef database update

Execute o programa console demo:

    dotnet run

    Use o menu para listar, inserir, atualizar e deletar filiais (e futuramente outros dados)

🗃️ Banco de Dados
Tabelas principais incluídas

    Filial: id, nome, endereço, custo operacional, faturamento

    Funcionario: dados pessoais, setor, filial, salário, faltas

    Setor: nomes dos setores (Gerência, Estoque, Atendimento, etc)

    Filme: título, gênero, estoque, sinopse, preço

    Cliente: dados para locação

    Aluguel: registro de aluguéis e devoluções

    AvaliaçãoFilme: avaliações de clientes com nota e comentário

⚙️ Automação com SQL

    Triggers: controle automático de estoque, atualização de notas médias

    Procedures: cadastro de aluguel, movimentação de funcionários

    Functions: cálculo de faturamento e médias

📈 Próximos passos (fora do escopo demo)

    Interface gráfica com Avalonia

    Sistema completo de login e permissões

    Relatórios gerenciais e dashboards

    Integração com sistema financeiro

    Perfeito! Vou gerar para você um conjunto básico de arquivos essenciais para a demo do banco funcional da locadora, alinhado com o README que preparei.

Vou criar:

    LocadoraDbContext.cs com as entidades principais (Filial, Funcionario, Setor).

    Modelos básicos: Filial.cs, Funcionario.cs, Setor.cs.

    Um Program.cs simplificado que cria o banco e faz CRUD em Filiais (como no exemplo do menu).

    Um arquivo SQL básico para seeds (criação da filial central e setores principais).

Vou montar e te enviar em seguida.

Aqui está o conjunto básico para o banco funcional da locadora que você pode usar como demo:
1. Data/LocadoraDbContext.cs

using Microsoft.EntityFrameworkCore;

public class LocadoraDbContext : DbContext
{
    public DbSet<Filial> Filiais { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Setor> Setores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=locadora.db");
}

2. Models/Filial.cs

using System.Collections.Generic;

public class Filial
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public decimal CustoOperacional { get; set; }
    public decimal Faturamento { get; set; }

    public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
}

3. Models/Setor.cs

using System.Collections.Generic;

public class Setor
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
}

4. Models/Funcionario.cs

using System;

public class Funcionario
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;
    public string Sexo { get; set; } = string.Empty;
    public string UsuarioId { get; set; } = string.Empty;
    public DateTime DataAniversario { get; set; }
    public decimal Salario { get; set; }
    public int DiasTrabalhados { get; set; }
    public int FaltasNaoJustificadas { get; set; }
    public string NivelAcesso { get; set; } = "Funcionario";

    public int FilialId { get; set; }
    public Filial Filial { get; set; } = null!;

    public int SetorId { get; set; }
    public Setor Setor { get; set; } = null!;
}

5. Program.cs

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        using var db = new LocadoraDbContext();
        db.Database.EnsureCreated();

        Console.WriteLine("Bem-vindo ao sistema demo da Locadora de Filmes!");
        int opcao;

        do
        {
            Console.WriteLine("\nCRUD FILIAIS");
            Console.WriteLine("1. Listar filiais");
            Console.WriteLine("2. Inserir filial");
            Console.WriteLine("3. Atualizar filial");
            Console.WriteLine("4. Deletar filial");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Entrada inválida.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    var filiais = db.Filiais.ToList();
                    if (filiais.Count == 0)
                        Console.WriteLine("Nenhuma filial cadastrada.");
                    else
                        foreach (var f in filiais)
                            Console.WriteLine($"Id: {f.Id}, Nome: {f.Nome}, Endereço: {f.Endereco}");
                    break;

                case 2:
                    Console.Write("Nome da filial: ");
                    var nome = Console.ReadLine() ?? string.Empty;
                    Console.Write("Endereço da filial: ");
                    var endereco = Console.ReadLine() ?? string.Empty;

                    var novaFilial = new Filial
                    {
                        Nome = nome,
                        Endereco = endereco,
                        CustoOperacional = 0,
                        Faturamento = 0
                    };

                    db.Filiais.Add(novaFilial);
                    db.SaveChanges();
                    Console.WriteLine("Filial inserida com sucesso!");
                    break;

                case 3:
                    Console.Write("Id da filial para atualizar: ");
                    if (int.TryParse(Console.ReadLine(), out int idUp))
                    {
                        var filialUp = db.Filiais.Find(idUp);
                        if (filialUp != null)
                        {
                            Console.Write($"Novo nome (atual: {filialUp.Nome}): ");
                            var novoNome = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(novoNome))
                                filialUp.Nome = novoNome;

                            Console.Write($"Novo endereço (atual: {filialUp.Endereco}): ");
                            var novoEndereco = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(novoEndereco))
                                filialUp.Endereco = novoEndereco;

                            db.SaveChanges();
                            Console.WriteLine("Filial atualizada!");
                        }
                        else
                        {
                            Console.WriteLine("Filial não encontrada.");
                        }
                    }
                    else
                        Console.WriteLine("Id inválido.");
                    break;

                case 4:
                    Console.Write("Id da filial para deletar: ");
                    if (int.TryParse(Console.ReadLine(), out int idDel))
                    {
                        var filialDel = db.Filiais.Find(idDel);
                        if (filialDel != null)
                        {
                            db.Filiais.Remove(filialDel);
                            db.SaveChanges();
                            Console.WriteLine("Filial deletada!");
                        }
                        else
                        {
                            Console.WriteLine("Filial não encontrada.");
                        }
                    }
                    else
                        Console.WriteLine("Id inválido.");
                    break;

                case 0:
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

        } while (opcao != 0);
    }
}

6. SQL/seeds.sql

-- Inserir filial central
INSERT INTO Filiais (Nome, Endereco, CustoOperacional, Faturamento)
VALUES ('Filial Central', 'Rua Principal, 123 - Centro', 0.00, 0.00);

-- Inserir setores principais
INSERT INTO Setores (Nome) VALUES ('Gerência');
INSERT INTO Setores (Nome) VALUES ('Atendimento');
INSERT INTO Setores (Nome) VALUES ('Estoquista');
INSERT INTO Setores (Nome) VALUES ('Serviços Gerais');
INSERT INTO Setores (Nome) VALUES ('Administrador');

---------------------------

Sobre o code IntialCreate.cs:

No terminal, na pasta do projeto, execute:

dotnet ef migrations add InitialCreate
dotnet ef database update

O banco locadora.db será criado com as tabelas acima.

Depois, rode o seeds.sql para inserir dados iniciais (Filial Central, Setores).

_____________________________________

tem tambem que criar um:
"Se quiser, posso ajudar com o arquivo seeds.sql pronto para rodar no SQLite, e até um passo a passo de como rodar esse script. Quer?"
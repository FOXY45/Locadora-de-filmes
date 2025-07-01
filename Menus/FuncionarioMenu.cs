using System;
using Models;
using Services;

namespace Menus;

public static class FuncionarioMenu
{
    public static void Exibir(Funcionario usuarioLogado, FuncionarioService funcionarioService)
    {
        int opcao;
        do
        {
            Console.WriteLine("\n==== MENU FUNCIONÁRIOS ====");
            Console.WriteLine($"Usuário atual: {usuarioLogado.Nome} | Nível: {usuarioLogado.NivelAcesso}");
            Console.WriteLine("1. Listar funcionários");
            Console.WriteLine("2. Inserir novo funcionário");
            Console.WriteLine("3. Atualizar funcionário");
            Console.WriteLine("4. Deletar funcionário");
            Console.WriteLine("5. Promover funcionário a administrador");
            Console.WriteLine("0. Voltar");
            Console.Write("Opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida, tente novamente.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    ListarFuncionarios(funcionarioService);
                    break;
                case 2:
                    InserirFuncionario(funcionarioService);
                    break;
                case 3:
                    AtualizarFuncionario(funcionarioService);
                    break;
                case 4:
                    if (usuarioLogado.NivelAcesso != "Administrador")
                    {
                        Console.WriteLine("Acesso negado. Apenas administradores podem deletar funcionários.");
                        break;
                    }
                    DeletarFuncionario(funcionarioService);
                    break;
                case 5:
                    if (usuarioLogado.NivelAcesso != "Administrador")
                    {
                        Console.WriteLine("Acesso negado. Apenas administradores podem promover funcionários.");
                        break;
                    }
                    PromoverFuncionario(funcionarioService);
                    break;
                case 0:
                    Console.WriteLine("Voltando ao menu principal...");
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }

        } while (opcao != 0);
    }

    private static void ListarFuncionarios(FuncionarioService service)
    {
        var funcionarios = service.ListarTodos();
        if (funcionarios.Count == 0)
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
            return;
        }

        Console.WriteLine("\nLista de funcionários:");
        foreach (var f in funcionarios)
        {
            Console.WriteLine($"Id: {f.Id} | Nome: {f.Nome} | Usuário: {f.UsuarioId} | Nível: {f.NivelAcesso}");
        }
    }

    private static void InserirFuncionario(FuncionarioService service)
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("Sexo (M/F/Outro): ");
        string sexo = Console.ReadLine() ?? string.Empty;

        Console.Write("Usuário (login único): ");
        string usuarioId = Console.ReadLine() ?? string.Empty;

        Console.Write("Data de aniversário (yyyy-MM-dd): ");
        DateTime dataAniversario;
        while (!DateTime.TryParse(Console.ReadLine(), out dataAniversario))
            Console.Write("Data inválida. Informe no formato yyyy-MM-dd: ");

        Console.Write("Salário: ");
        decimal salario;
        while (!decimal.TryParse(Console.ReadLine(), out salario))
            Console.Write("Valor inválido. Informe o salário: ");

        // Para simplicidade, fixaremos Filial e Setor padrão (1) — pode ser editado depois
        var novoFuncionario = new Funcionario
        {
            Nome = nome,
            Sexo = sexo,
            UsuarioId = usuarioId,
            DataAniversario = dataAniversario,
            Salario = salario,
            DiasTrabalhados = 0,
            FaltasNaoJustificadas = 0,
            NivelAcesso = "Funcionario",
            FilialId = 1,
            SetorId = 1
        };

        service.Inserir(novoFuncionario);
        Console.WriteLine("Funcionário inserido com sucesso!");
    }

    private static void AtualizarFuncionario(FuncionarioService service)
    {
        Console.Write("Id do funcionário a atualizar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        var func = service.ListarTodos().Find(f => f.Id == id);
        if (func == null)
        {
            Console.WriteLine("Funcionário não encontrado.");
            return;
        }

        Console.Write($"Nome ({func.Nome}): ");
        var nome = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nome))
            func.Nome = nome;

        Console.Write($"Sexo ({func.Sexo}): ");
        var sexo = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(sexo))
            func.Sexo = sexo;

        Console.Write($"Usuário ({func.UsuarioId}): ");
        var usuarioId = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(usuarioId))
            func.UsuarioId = usuarioId;

        Console.Write($"Data de aniversário ({func.DataAniversario:yyyy-MM-dd}): ");
        var dataStr = Console.ReadLine();
        if (DateTime.TryParse(dataStr, out var novaData))
            func.DataAniversario = novaData;

        Console.Write($"Salário ({func.Salario}): ");
        var salarioStr = Console.ReadLine();
        if (decimal.TryParse(salarioStr, out var novoSalario))
            func.Salario = novoSalario;

        service.Atualizar(func);
        Console.WriteLine("Funcionário atualizado com sucesso!");
    }

    private static void DeletarFuncionario(FuncionarioService service)
    {
        Console.Write("Id do funcionário a deletar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        if (service.Deletar(id))
            Console.WriteLine("Funcionário deletado com sucesso.");
        else
            Console.WriteLine("Funcionário não encontrado.");
    }

    private static void PromoverFuncionario(FuncionarioService service)
    {
        Console.Write("Usuário do funcionário a promover: ");
        string usuarioId = Console.ReadLine() ?? string.Empty;

        var func = service.ListarTodos().Find(f => f.UsuarioId == usuarioId);
        if (func == null)
        {
            Console.WriteLine("Funcionário não encontrado.");
            return;
        }

        if (func.NivelAcesso == "Administrador")
        {
            Console.WriteLine("Funcionário já é administrador.");
            return;
        }

        func.NivelAcesso = "Administrador";
        service.Atualizar(func);
        Console.WriteLine($"Funcionário {func.Nome} promovido a administrador com sucesso!");
    }
}

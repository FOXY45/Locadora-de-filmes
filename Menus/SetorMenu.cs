using System;
using Models;
using Services;

namespace Menus;

public static class SetorMenu
{
    public static void Exibir(SetorService setorService)
    {
        int opcao;
        do
        {
            Console.WriteLine("\n==== MENU SETORES ====");
            Console.WriteLine("1. Listar setores");
            Console.WriteLine("2. Inserir novo setor");
            Console.WriteLine("3. Atualizar setor");
            Console.WriteLine("4. Deletar setor");
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
                    ListarSetores(setorService);
                    break;
                case 2:
                    InserirSetor(setorService);
                    break;
                case 3:
                    AtualizarSetor(setorService);
                    break;
                case 4:
                    DeletarSetor(setorService);
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

    private static void ListarSetores(SetorService service)
    {
        var setores = service.ListarTodos();
        if (setores.Count == 0)
        {
            Console.WriteLine("Nenhum setor cadastrado.");
            return;
        }

        Console.WriteLine("\nLista de setores:");
        foreach (var s in setores)
        {
            Console.WriteLine($"Id: {s.Id} | Nome: {s.Nome}");
        }
    }

    private static void InserirSetor(SetorService service)
    {
        Console.Write("Nome do setor: ");
        string nome = Console.ReadLine() ?? string.Empty;

        service.Inserir(nome);
        Console.WriteLine("Setor inserido com sucesso!");
    }

    private static void AtualizarSetor(SetorService service)
    {
        Console.Write("Id do setor a atualizar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        Console.Write("Novo nome do setor: ");
        var nome = Console.ReadLine() ?? string.Empty;

        if (service.Atualizar(id, nome))
            Console.WriteLine("Setor atualizado com sucesso!");
        else
            Console.WriteLine("Setor não encontrado.");
    }

    private static void DeletarSetor(SetorService service)
    {
        Console.Write("Id do setor a deletar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        if (service.Deletar(id))
            Console.WriteLine("Setor deletado com sucesso.");
        else
            Console.WriteLine("Setor não encontrado.");
    }
}

using System;
using Models;
using Services;

namespace Menus;

public static class FilmeMenu
{
    public static void Exibir(FilmeService filmeService)
    {
        int opcao;
        do
        {
            Console.WriteLine("\n==== MENU FILMES ====");
            Console.WriteLine("1. Listar filmes");
            Console.WriteLine("2. Inserir novo filme");
            Console.WriteLine("3. Atualizar filme");
            Console.WriteLine("4. Deletar filme");
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
                    ListarFilmes(filmeService);
                    break;
                case 2:
                    InserirFilme(filmeService);
                    break;
                case 3:
                    AtualizarFilme(filmeService);
                    break;
                case 4:
                    DeletarFilme(filmeService);
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

    private static void ListarFilmes(FilmeService service)
    {
        var filmes = service.ListarTodos();
        if (filmes.Count == 0)
        {
            Console.WriteLine("Nenhum filme cadastrado.");
            return;
        }

        Console.WriteLine("\nLista de filmes:");
        foreach (var f in filmes)
        {
            Console.WriteLine($"Id: {f.Id} | Título: {f.Titulo} | Gênero: {f.Genero} | Nota média: {f.NotaMedia} | Sinopse: {f.Sinopse}");
        }
    }

    private static void InserirFilme(FilmeService service)
    {
        Console.Write("Título: ");
        string titulo = Console.ReadLine() ?? string.Empty;

        Console.Write("Gênero: ");
        string genero = Console.ReadLine() ?? string.Empty;

        Console.Write("Nota média (0 a 10): ");
        decimal notaMedia;
        while (!decimal.TryParse(Console.ReadLine(), out notaMedia) || notaMedia < 0 || notaMedia > 10)
            Console.Write("Nota inválida. Informe uma nota de 0 a 10: ");

        Console.Write("Sinopse: ");
        string sinopse = Console.ReadLine() ?? string.Empty;

        service.Inserir(titulo, genero, (double)notaMedia, sinopse);
        Console.WriteLine("Filme inserido com sucesso!");
    }

    private static void AtualizarFilme(FilmeService service)
    {
        Console.Write("Id do filme a atualizar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        var filme = service.ListarTodos().Find(f => f.Id == id);
        if (filme == null)
        {
            Console.WriteLine("Filme não encontrado.");
            return;
        }

        Console.Write($"Título ({filme.Titulo}): ");
        var novoTitulo = Console.ReadLine();

        Console.Write($"Gênero ({filme.Genero}): ");
        var novoGenero = Console.ReadLine();

        Console.Write($"Nota média ({filme.NotaMedia}): ");
        var notaStr = Console.ReadLine();
        double? novaNota = null;
        if (double.TryParse(notaStr, out var notaParsed) && notaParsed >= 0 && notaParsed <= 10)
            novaNota = notaParsed;

        Console.Write($"Sinopse ({filme.Sinopse}): ");
        var novaSinopse = Console.ReadLine();

        service.Atualizar(id, novoTitulo, novoGenero, novaNota, novaSinopse);
        Console.WriteLine("Filme atualizado com sucesso!");
    }

    private static void DeletarFilme(FilmeService service)
    {
        Console.Write("Id do filme a deletar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        if (service.Deletar(id))
            Console.WriteLine("Filme deletado com sucesso.");
        else
            Console.WriteLine("Filme não encontrado.");
    }
}

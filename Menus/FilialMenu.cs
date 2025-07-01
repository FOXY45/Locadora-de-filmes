using System;
using Services;
using Models;

namespace Menus;

public class FilialMenu
{
    public static void Exibir(FilialService filialService)
    {
        int opcao;
        do
        {
            Console.WriteLine("\n==== MENU - CRUD FILIAIS ====");
            Console.WriteLine("1. Listar filiais");
            Console.WriteLine("2. Inserir nova filial");
            Console.WriteLine("3. Atualizar filial");
            Console.WriteLine("4. Deletar filial");
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
                    var filiais = filialService.ListarTodas();
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

                    filialService.Inserir(nome, endereco);
                    Console.WriteLine("Filial inserida com sucesso!");
                    break;

                case 3:
                    Console.Write("Id da filial a atualizar: ");
                    if (int.TryParse(Console.ReadLine(), out int idUp))
                    {
                        Console.Write("Novo nome (pressione Enter para manter): ");
                        var novoNome = Console.ReadLine();

                        Console.Write("Novo endereço (pressione Enter para manter): ");
                        var novoEndereco = Console.ReadLine();

                        var atualizado = filialService.Atualizar(idUp, novoNome, novoEndereco);
                        Console.WriteLine(atualizado ? "Filial atualizada com sucesso!" : "Filial não encontrada.");
                    }
                    else
                        Console.WriteLine("Id inválido.");
                    break;

                case 4:
                    Console.Write("Id da filial a deletar: ");
                    if (int.TryParse(Console.ReadLine(), out int idDel))
                    {
                        var deletado = filialService.Deletar(idDel);
                        Console.WriteLine(deletado ? "Filial deletada com sucesso!" : "Filial não encontrada.");
                    }
                    else
                        Console.WriteLine("Id inválido.");
                    break;

                case 0:
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }

        } while (opcao != 0);
    }
}

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        using var db = new LocadoraDbContext();
        db.Database.EnsureCreated();

        int opcao;
        do
        {
            Console.WriteLine("\nCRUD FILIAIS");
            Console.WriteLine("1. Listar filiais");
            Console.WriteLine("2. Inserir nova filial");
            Console.WriteLine("3. Atualizar filial");
            Console.WriteLine("4. Deletar filial");
            Console.WriteLine("0. Sair\n");
            Console.Write("Opção: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida, tente novamente.");
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
                    Console.Write("Id da filial a atualizar: ");
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
                            Console.WriteLine("Filial atualizada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Filial não encontrada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Id inválido.");
                    }
                    break;

                case 4:
                    Console.Write("Id da filial a deletar: ");
                    if (int.TryParse(Console.ReadLine(), out int idDel))
                    {
                        var filialDel = db.Filiais.Find(idDel);
                        if (filialDel != null)
                        {
                            db.Filiais.Remove(filialDel);
                            db.SaveChanges();
                            Console.WriteLine("Filial deletada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Filial não encontrada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Id inválido.");
                    }
                    break;

                case 0:
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }

        } while (opcao != 0);
    }
}

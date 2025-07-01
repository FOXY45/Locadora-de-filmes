using Models;
using Services;

namespace Menus;

public static class EstoqueMenu
{
    public static void Exibir(EstoqueService estoqueService)
    {
        int opcao;
        do
        {
            Console.WriteLine("\n==== MENU ESTOQUE ====");
            Console.WriteLine("1. Listar estoque");
            Console.WriteLine("2. Adicionar ao estoque");
            Console.WriteLine("3. Alugar filme");
            Console.WriteLine("4. Registrar devolução");
            Console.WriteLine("0. Voltar");
            Console.Write("Opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    foreach (var e in estoqueService.ListarTodos())
                    {
                        Console.WriteLine($"FilmeId: {e.FilmeId} | FilialId: {e.FilialId} | Disponíveis: {e.QuantidadeDisponivel} | Alugados: {e.QuantidadeAlugada}");
                    }
                    break;

                case 2:
                    Console.Write("Filme ID: ");
                    int filmeId = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Filial ID: ");
                    int filialId = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Quantidade a adicionar: ");
                    int qtd = int.Parse(Console.ReadLine() ?? "0");
                    estoqueService.Adicionar(filmeId, filialId, qtd);
                    Console.WriteLine("Estoque atualizado.");
                    break;

                case 3:
                    Console.Write("Filme ID: ");
                    filmeId = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Filial ID: ");
                    filialId = int.Parse(Console.ReadLine() ?? "0");
                    if (estoqueService.AlugarFilme(filmeId, filialId))
                        Console.WriteLine("Aluguel registrado.");
                    else
                        Console.WriteLine("Erro: Sem disponibilidade.");
                    break;

                case 4:
                    Console.Write("Filme ID: ");
                    filmeId = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Filial ID: ");
                    filialId = int.Parse(Console.ReadLine() ?? "0");
                    if (estoqueService.RegistrarDevolucao(filmeId, filialId))
                        Console.WriteLine("Devolução registrada.");
                    else
                        Console.WriteLine("Erro: Nenhuma cópia alugada.");
                    break;
            }

        } while (opcao != 0);
    }
}

using System;
using Models;
using Services;

namespace Menus;

public static class MenuPrincipal
{
    public static void Exibir(Funcionario usuarioLogado, LocadoraDbContext db)
    {
        var filialService = new FilialService(db);
        var funcionarioService = new FuncionarioService(db);
        var setorService = new SetorService(db);
        var filmeService = new FilmeService(db); // Adicionei o FilmeService aqui
        var estoqueService = new EstoqueService(db);


        int opcao;
        do
        {
            Console.WriteLine("\n==== MENU PRINCIPAL ====");
            Console.WriteLine($"Usuário: {usuarioLogado.Nome} | Nível: {usuarioLogado.NivelAcesso}");
            Console.WriteLine("1. Gerenciar Filiais");
            Console.WriteLine("2. Gerenciar Filmes");
            Console.WriteLine("3. Gerenciar Funcionários");
            Console.WriteLine("4. Gerenciar Setores");
            Console.WriteLine("5. Logout");
            Console.WriteLine("6. Gerenciar Estoque");

            Console.Write("Opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida, tente novamente.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    FilialMenu.Exibir(filialService);
                    break;
                case 2:
                    FilmeMenu.Exibir(filmeService);  // Passando o filmeService correto
                    break;
                case 3:
                    FuncionarioMenu.Exibir(usuarioLogado, funcionarioService ); // Passando o serviço e o usuário logado
                    break;
                case 4:
                    SetorMenu.Exibir(setorService);
                    break;
                case 5:
                    Console.WriteLine("Logout efetuado.");
                    opcao = 0; // Sai do menu principal e volta ao programa principal
                    break;
                case 6:
                    EstoqueMenu.Exibir(estoqueService);
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        } while (opcao != 0);
    }
}

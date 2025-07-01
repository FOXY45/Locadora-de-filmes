using System;
using Models;
using Services;

namespace Menus;

public static class LoginMenu
{
    public static Funcionario? Executar(LoginService loginService)
    {
        Console.WriteLine("==== LOGIN ====");

        while (true)
        {
            Console.Write("Usuário: ");
            string usuario = Console.ReadLine() ?? "";

            Console.Write("Senha: ");
            string senha = LerSenha();

            var funcionario = loginService.Autenticar(usuario, senha);

            if (funcionario == null)
            {
                Console.WriteLine("❌ Login inválido. Tente novamente.");
                continue;
            }

            Console.WriteLine($"\n✅ Bem-vindo, {funcionario.Nome}!");

            Console.Write("Manter conectado nesta sessão? (s/n): ");
            var manter = Console.ReadLine()?.ToLower();

            return funcionario;
        }
    }

    // Oculta senha digitada (para deixar mais profissional)
    private static string LerSenha()
    {
        string senha = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(intercept: true);

            if (key.Key == ConsoleKey.Backspace && senha.Length > 0)
            {
                senha = senha[..^1];
                Console.Write("\b \b");
            }
            else if (!char.IsControl(key.KeyChar))
            {
                senha += key.KeyChar;
                Console.Write("*");
            }

        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return senha;
    }
}

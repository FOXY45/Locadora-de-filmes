using Models;
using Services;

namespace Menus;

public static class LoginMenu
{
    public static Funcionario? Executar(LoginService loginService)
    {
        Funcionario? usuarioLogado = null;

        do
        {
            Console.WriteLine("\n==== LOGIN ====");
            Console.Write("Usuário: ");
            string usuario = Console.ReadLine() ?? "";

            Console.Write("Senha: ");
            string senha = Console.ReadLine() ?? "";

            usuarioLogado = loginService.Autenticar(usuario, senha);

            if (usuarioLogado == null)
            {
                Console.WriteLine("Usuário ou senha inválidos. Tente novamente.\n");
            }

        } while (usuarioLogado == null);

        return usuarioLogado;
    }
}

using Menus;
using Services;

public class Program
{
    public static void Main()
    {
        using var db = new LocadoraDbContext();
        db.Database.EnsureCreated();

        var loginService = new LoginService(db);

        var usuarioLogado = LoginMenu.Executar(loginService);

        if (usuarioLogado is not null)
        {
            MenuPrincipal.Exibir(usuarioLogado, db); // Redireciona após login
        }
        else
        {
            Console.WriteLine("Encerrando aplicação.");
        }
    }
}

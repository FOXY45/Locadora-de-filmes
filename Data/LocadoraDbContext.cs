using Microsoft.EntityFrameworkCore;
using Models;

public class LocadoraDbContext : DbContext
{
    public DbSet<Filial> Filiais { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Setor> Setores { get; set; }

    public DbSet<Filme> Filmes { get; set; } // ✅ Adicionado

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=locadora.db");
}




/*se apresentar erros no MYSQL altere a linha acima por 
    options.UseMySql("Server=localhost;Database=locadora;User=root;Password=senha;", 
    new MySqlServerVersion(new Version(8, 0, 36)));
*/

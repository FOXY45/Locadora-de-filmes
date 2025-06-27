using Microsoft.EntityFrameworkCore;

public class LocadoraDbContext : DbContext
{
    public DbSet<Filial> Filiais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=locadora.db");
}

using System.Collections.Generic;
using System.Linq;
using Models;

public class FilmeService
{
    private readonly LocadoraDbContext _context;

    public FilmeService(LocadoraDbContext context)
    {
        _context = context;
    }

    // ===== LISTAGEM E CONSULTA =====
    public List<Filme> ListarTodos()
    {
        return _context.Filmes
            .OrderBy(f => f.Titulo)
            .ToList();
    }

    public List<Filme> FiltrarPorGenero(string genero)
    {
        return _context.Filmes
            .Where(f => f.Genero.ToLower() == genero.ToLower())
            .OrderBy(f => f.Titulo)
            .ToList();
    }

    public List<Filme> TopPorNota(int quantidade = 3)
    {
        return _context.Filmes
            .OrderByDescending(f => f.NotaMedia)
            .Take(quantidade)
            .ToList();
    }

    // ===== INSERÇÃO =====
    public void Inserir(string titulo, string genero, double notaMedia, string sinopse)
    {
        var filme = new Filme
        {
            Titulo = titulo,
            Genero = genero,
            NotaMedia = notaMedia,
            Sinopse = sinopse
        };

        _context.Filmes.Add(filme);
        _context.SaveChanges();
    }

    // ===== ATUALIZAÇÃO =====
    public bool Atualizar(int id, string? novoTitulo, string? novoGenero, double? novaNota, string? novaSinopse)
    {
        var filme = _context.Filmes.Find(id);
        if (filme == null) return false;

        if (!string.IsNullOrWhiteSpace(novoTitulo))
            filme.Titulo = novoTitulo;

        if (!string.IsNullOrWhiteSpace(novoGenero))
            filme.Genero = novoGenero;

        if (novaNota is not null)
            filme.NotaMedia = novaNota.Value;

        if (!string.IsNullOrWhiteSpace(novaSinopse))
            filme.Sinopse = novaSinopse;

        _context.SaveChanges();
        return true;
    }

    // ===== REMOÇÃO =====
    public bool Deletar(int id)
    {
        var filme = _context.Filmes.Find(id);
        if (filme == null) return false;

        _context.Filmes.Remove(filme);
        _context.SaveChanges();
        return true;
    }
}

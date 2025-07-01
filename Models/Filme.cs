using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Filme
{
    public int Id { get; set; }

    [Required]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    public string Genero { get; set; } = string.Empty;

    [Range(0, 10)]
    public double NotaMedia { get; set; } = 0;

    public string Sinopse { get; set; } = string.Empty;

    // Futuramente: estoques, disponibilidade, histórico de aluguel, etc.
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Estoque
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Filme")]
    public int FilmeId { get; set; }

    [ForeignKey("Filial")]
    public int FilialId { get; set; }

    public int QuantidadeDisponivel { get; set; }
    public int QuantidadeAlugada { get; set; }

    public virtual Filme? Filme { get; set; }
    public virtual Filial? Filial { get; set; }
}

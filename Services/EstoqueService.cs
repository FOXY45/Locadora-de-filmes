using Models;

public class EstoqueService
{
    private readonly LocadoraDbContext _context;

    public EstoqueService(LocadoraDbContext context)
    {
        _context = context;
    }

    public List<Estoque> ListarTodos()
    {
        return _context.Estoques.ToList();
    }

    public void Adicionar(int filmeId, int filialId, int quantidade)
    {
        var estoque = _context.Estoques
            .FirstOrDefault(e => e.FilmeId == filmeId && e.FilialId == filialId);

        if (estoque == null)
        {
            estoque = new Estoque
            {
                FilmeId = filmeId,
                FilialId = filialId,
                QuantidadeDisponivel = quantidade,
                QuantidadeAlugada = 0
            };
            _context.Estoques.Add(estoque);
        }
        else
        {
            estoque.QuantidadeDisponivel += quantidade;
        }

        _context.SaveChanges();
    }

    public bool AlugarFilme(int filmeId, int filialId)
    {
        var estoque = _context.Estoques
            .FirstOrDefault(e => e.FilmeId == filmeId && e.FilialId == filialId);

        if (estoque == null || estoque.QuantidadeDisponivel <= 0)
            return false;

        estoque.QuantidadeDisponivel--;
        estoque.QuantidadeAlugada++;
        _context.SaveChanges();
        return true;
    }

    public bool RegistrarDevolucao(int filmeId, int filialId)
    {
        var estoque = _context.Estoques
            .FirstOrDefault(e => e.FilmeId == filmeId && e.FilialId == filialId);

        if (estoque == null || estoque.QuantidadeAlugada <= 0)
            return false;

        estoque.QuantidadeAlugada--;
        estoque.QuantidadeDisponivel++;
        _context.SaveChanges();
        return true;
    }
}

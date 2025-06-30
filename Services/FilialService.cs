using System.Collections.Generic;
using System.Linq;
using Models;

namespace Services
{
    public class FilialService
    {
        private readonly LocadoraDbContext _context;

        public FilialService(LocadoraDbContext context)
        {
            _context = context;
        }

        public List<Filial> ListarTodas()
        {
            return _context.Filiais.ToList();
        }

        public void Inserir(string nome, string endereco)
        {
            var filial = new Filial
            {
                Nome = nome,
                Endereco = endereco,
                CustoOperacional = 0,
                Faturamento = 0
            };

            _context.Filiais.Add(filial);
            _context.SaveChanges();
        }

        public bool Atualizar(int id, string? novoNome, string? novoEndereco)
        {
            var filial = _context.Filiais.Find(id);
            if (filial == null) return false;

            if (!string.IsNullOrWhiteSpace(novoNome))
                filial.Nome = novoNome;

            if (!string.IsNullOrWhiteSpace(novoEndereco))
                filial.Endereco = novoEndereco;

            _context.SaveChanges();
            return true;
        }

        public bool Deletar(int id)
        {
            var filial = _context.Filiais.Find(id);
            if (filial == null) return false;

            _context.Filiais.Remove(filial);
            _context.SaveChanges();
            return true;
        }
    }
}

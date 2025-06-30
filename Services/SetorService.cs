using System.Collections.Generic;
using System.Linq;
using Models;

namespace Services
{
    public class SetorService
    {
        private readonly LocadoraDbContext _context;

        public SetorService(LocadoraDbContext context)
        {
            _context = context;
        }

        public List<Setor> ListarTodos()
        {
            return _context.Setores.ToList();
        }

        public void Inserir(string nome)
        {
            var setor = new Setor { Nome = nome };
            _context.Setores.Add(setor);
            _context.SaveChanges();
        }

        public bool Atualizar(int id, string novoNome)
        {
            var setor = _context.Setores.Find(id);
            if (setor == null) return false;

            setor.Nome = novoNome;
            _context.SaveChanges();
            return true;
        }

        public bool Deletar(int id)
        {
            var setor = _context.Setores.Find(id);
            if (setor == null) return false;

            _context.Setores.Remove(setor);
            _context.SaveChanges();
            return true;
        }
    }
}

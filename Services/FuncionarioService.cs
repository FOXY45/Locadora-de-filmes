using System.Collections.Generic;
using System.Linq;
using Models;

namespace Services
{
    public class FuncionarioService
    {
        private readonly LocadoraDbContext _context;

        public FuncionarioService(LocadoraDbContext context)
        {
            _context = context;
        }

        public List<Funcionario> ListarTodos()
        {
            return _context.Funcionarios
                .OrderBy(f => f.Nome)
                .ToList();
        }

        public void Inserir(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
        }

        public bool Atualizar(Funcionario dados)
        {
            var funcionario = _context.Funcionarios.Find(dados.Id);
            if (funcionario == null) return false;

            funcionario.Nome = dados.Nome;
            funcionario.Sexo = dados.Sexo;
            funcionario.UsuarioId = dados.UsuarioId;
            funcionario.DataAniversario = dados.DataAniversario;
            funcionario.Salario = dados.Salario;
            funcionario.DiasTrabalhados = dados.DiasTrabalhados;
            funcionario.FaltasNaoJustificadas = dados.FaltasNaoJustificadas;
            funcionario.NivelAcesso = dados.NivelAcesso;
            funcionario.FilialId = dados.FilialId;
            funcionario.SetorId = dados.SetorId;

            _context.SaveChanges();
            return true;
        }

        public bool Deletar(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario == null) return false;

            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
            return true;
        }
    }
}

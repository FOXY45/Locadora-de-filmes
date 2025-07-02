using System;
using System.Linq;
using Models;

namespace Services
{
    public class LoginService
    {
        private readonly LocadoraDbContext _context;

        public LoginService(LocadoraDbContext context)
        {
            _context = context;
            CriarAdminSeNaoExistir();
        }

        public void CriarAdminSeNaoExistir()
        {
            var adminExistente = _context.Funcionarios
                .Any(f => f.NivelAcesso == "Administrador");

            if (adminExistente)
                return;

            var filial = _context.Filiais.FirstOrDefault(f => f.Id == 1);
            if (filial == null)
            {
                filial = new Filial
                {
                    Nome = "Filial Padrão",
                    Endereco = "Endereço Padrão",
                    Faturamento = 0,
                    CustoOperacional = 0
                };
                _context.Filiais.Add(filial);
                _context.SaveChanges();
            }

            var setor = _context.Setores.FirstOrDefault(s => s.Id == 1);
            if (setor == null)
            {
                setor = new Setor
                {
                    Nome = "Setor Padrão"
                };
                _context.Setores.Add(setor);
                _context.SaveChanges();
            }

            var admin = new Funcionario
            {
                Nome = "Administrador",
                UsuarioId = "admin",
                NivelAcesso = "Administrador",
                FilialId = filial.Id,
                SetorId = setor.Id,
                Sexo = "Outro",
                DataAniversario = DateTime.Now.AddYears(-30),
                Salario = 0,
                DiasTrabalhados = 0,
                FaltasNaoJustificadas = 0
            };

            _context.Funcionarios.Add(admin);
            _context.SaveChanges();
        }

        // Método para autenticar um usuário
        public Funcionario? Autenticar(string usuarioId, string senha)
        {
            // Por enquanto, todos usam a senha padrão "adm123"
            var funcionario = _context.Funcionarios
                .FirstOrDefault(f => f.UsuarioId == usuarioId);

            if (funcionario == null)
                return null;

            if (senha == "adm123")
                return funcionario;

            return null;
        }
    }
}

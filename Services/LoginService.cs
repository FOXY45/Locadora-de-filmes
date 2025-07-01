using System;
using System.Linq;
using Models;

namespace Services;

public class LoginService
{
    private readonly LocadoraDbContext _context;
    private const string AdminUser = "admin";
    private const string AdminSenha = "adm123";

    public LoginService(LocadoraDbContext context)
    {
        _context = context;
        CriarAdminSeNaoExistir();
    }

    private void CriarAdminSeNaoExistir()
    {
        if (!_context.Funcionarios.Any(f => f.UsuarioId == AdminUser))
        {
            var admin = new Funcionario
            {
                Nome = "Administrador Principal",
                Sexo = "Outro",
                UsuarioId = AdminUser,
                DataAniversario = new DateTime(1990, 1, 1),
                Salario = 0,
                DiasTrabalhados = 0,
                FaltasNaoJustificadas = 0,
                NivelAcesso = "Administrador",
                FilialId = _context.Filiais.FirstOrDefault()?.Id ?? 1,
                SetorId = _context.Setores.FirstOrDefault()?.Id ?? 1
            };

            _context.Funcionarios.Add(admin);
            _context.SaveChanges();
            Console.WriteLine("⚠️  Administrador padrão criado: login = admin, senha = adm123");
        }
    }

    public Funcionario? Autenticar(string usuarioId, string senha)
    {
        // Apenas o admin tem verificação de senha por enquanto
        var funcionario = _context.Funcionarios.FirstOrDefault(f => f.UsuarioId == usuarioId);

        if (funcionario == null) return null;

        if (usuarioId == AdminUser)
        {
            if (senha == AdminSenha) return funcionario;
            return null;
        }

        // Para outros usuários, a senha pode ser ignorada ou tratada depois
        return funcionario;
    }

    public bool PodePromover(Funcionario solicitante, Funcionario alvo)
    {
        // Só o admin original pode promover
        return solicitante.UsuarioId == AdminUser && alvo.NivelAcesso != "Administrador";
    }

    public bool PromoverParaAdmin(Funcionario solicitante, string usuarioId)
    {
        var funcionario = _context.Funcionarios.FirstOrDefault(f => f.UsuarioId == usuarioId);
        if (funcionario == null)
            return false;

        if (!PodePromover(solicitante, funcionario))
            return false;

        funcionario.NivelAcesso = "Administrador";
        _context.SaveChanges();
        return true;
    }

}

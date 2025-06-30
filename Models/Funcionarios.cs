using System;

namespace Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty; // Pode ser "M", "F", "Outro" ou enum
        public string UsuarioId { get; set; } = string.Empty; // Login único
        public DateTime DataAniversario { get; set; }
        public decimal Salario { get; set; }

        public int DiasTrabalhados { get; set; }
        public int FaltasNaoJustificadas { get; set; }

        public string NivelAcesso { get; set; } = "Funcionario"; // "Administrador" ou "Funcionario"

        // Relacionamento com Filial
        public int FilialId { get; set; }
        public Filial Filial { get; set; } = null!;

        // Relacionamento com Setor
        public int SetorId { get; set; }
        public Setor Setor { get; set; } = null!;
    }
}

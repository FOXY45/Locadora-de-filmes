using System.Collections.Generic;

namespace Models
{
    public class Filial
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;           // Ex: "Filial Central"
        public string Endereco { get; set; } = string.Empty;       // Localização física

        public decimal CustoOperacional { get; set; }              // Custos mensais ou acumulados
        public decimal Faturamento { get; set; }                   // Total em vendas/aluguéis

        // Relação com funcionários vinculados a essa filial
        public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}


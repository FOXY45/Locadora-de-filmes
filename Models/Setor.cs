using System.Collections.Generic;

namespace Models
{
    public class Setor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; // Ex: "Gerência", "Serviços Gerais", "Atendentes", "Estoquistas", "Balcão", "Administrador"

        public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}

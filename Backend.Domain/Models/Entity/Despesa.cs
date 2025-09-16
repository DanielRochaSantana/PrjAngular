using Backend.Domain.Models.Base;

namespace Backend.Domain.Models.Entity
{
    public class Despesa : BaseEntity
    {
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string Local { get; set; } = string.Empty;
    }
}

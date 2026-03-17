using Backend.Domain.Models.Base;

namespace Backend.Domain.Models.Entity
{
    public class Compromisso : BaseEntity
    {
        public string Descricao { get; set; } = string.Empty;
        public string HoraInicio { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
    }
}

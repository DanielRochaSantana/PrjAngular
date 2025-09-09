using Backend.Domain.Models.Base;

namespace Backend.Domain.Models.Entity
{
    public class Atividade : BaseEntity
    {
        public string Descricao { get;set;} = string.Empty;
        public string Horario { get;set;} = string.Empty;
        public string Local { get;set;} = string.Empty;
    }
}

using Backend.Domain.Models.Base;

namespace Backend.Domain.Models.Entity
{
    public class IntermediateAtividade : IntermediateBaseEntity
    {
        public string Descricao { get;set;} = string.Empty;
        public string Horario { get;set;} = string.Empty;
        public string Local { get;set;} = string.Empty;
    }
}

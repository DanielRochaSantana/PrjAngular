using Backend.Domain.Models.Base;

namespace Backend.Domain.Models.Entity
{
    public class IntermediateAtuacao : IntermediateBaseEntity
    {
        public string Descricao { get;set;} = string.Empty;
        public string Empresa { get; set; } = string.Empty;
        public string Local { get;set;} = string.Empty;
    }
}

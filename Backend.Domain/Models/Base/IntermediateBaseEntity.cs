namespace Backend.Domain.Models.Base
{
    public class IntermediateBaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime? DataModificacao { get; set; } = null;
        public bool IsAtivo { get; set; } = true;
    }
}
namespace Backend.Domain.Models.Base
{
    /// <summary>
    /// The BaseEntity class.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// The Id property.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// The DataCadastro property.
        /// </summary>
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        /// <summary>
        /// The DataModificacao property.
        /// </summary>
        public DateTime? DataModificacao { get; set; } = null;

        /// <summary>
        /// The IsAtivo property.
        /// </summary>
        public bool IsAtivo { get; set; } = true;
    }
}
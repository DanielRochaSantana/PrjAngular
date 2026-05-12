#region Usings
using Backend.Domain.Models.Base; 
#endregion Usings

namespace Backend.Domain.Models.Entity
{
    /// <summary>
    /// The Compromisso class.
    /// </summary>
    public class Compromisso : BaseEntity
    {
        /// <summary>
        /// The Descricao property.
        /// </summary>
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// The HoraInicio property.
        /// </summary>
        public string HoraInicio { get; set; } = string.Empty;

        /// <summary>
        /// The Local property.
        /// </summary>
        public string Local { get; set; } = string.Empty;
    }
}

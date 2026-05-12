#region Usings
using Backend.Domain.Models.Base;
#endregion Usings

namespace Backend.Domain.Models.Entity
{
    /// <summary>
    /// The Atuacao class.
    /// </summary>
    public class Atuacao : BaseEntity
    {
        /// <summary>
        /// The Descricao property.
        /// </summary>
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// The Empresa property.
        /// </summary>
        public string Empresa { get; set; } = string.Empty;

        /// <summary>
        /// The Local property.
        /// </summary>
        public string Local { get; set; } = string.Empty;
    }
}

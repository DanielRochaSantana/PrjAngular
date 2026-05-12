#region Usings
using Backend.Domain.Models.Base; 
#endregion Usings

namespace Backend.Domain.Models.Entity
{
    /// <summary>
    /// The Curso class that descends from BaseEntity.
    /// </summary>
    public class Curso : BaseEntity
    {
        /// <summary>
        /// The Descricao property.
        /// </summary>
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// The Instituicao property.
        /// </summary>
        public string Instituicao { get; set; } = string.Empty;

        /// <summary>
        /// The Local property.
        /// </summary>
        public string Local { get; set; } = string.Empty;
    }
}

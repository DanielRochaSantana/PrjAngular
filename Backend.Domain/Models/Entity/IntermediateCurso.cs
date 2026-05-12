#region Usings
using Backend.Domain.Models.Base; 
#endregion Usings

namespace Backend.Domain.Models.Entity
{
    /// <summary>
    /// The IntermediateCurso class that descends from IntermediateBaseEntity.
    /// </summary>
    public class IntermediateCurso : IntermediateBaseEntity
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

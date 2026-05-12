#region Usings
using Backend.Domain.Models.Base; 
#endregion Usings

namespace Backend.Domain.Models.Entity
{
    /// <summary>
    /// The IntermediateAtuacao class.
    /// </summary>
    public class IntermediateAtuacao : IntermediateBaseEntity
    {
        /// <summary>
        /// The Descricao property.
        /// </summary>
        public string Descricao { get;set;} = string.Empty;

        /// <summary>
        /// The Empresa property.
        /// </summary>
        public string Empresa { get; set; } = string.Empty;

        /// <summary>
        /// The Local property.
        /// </summary>
        public string Local { get;set;} = string.Empty;
    }
}

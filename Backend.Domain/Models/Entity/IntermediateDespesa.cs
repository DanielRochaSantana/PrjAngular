#region Usings
using Backend.Domain.Models.Base; 
#endregion Usings

namespace Backend.Domain.Models.Entity
{
    /// <summary>
    /// The IntermediateDespesa class.
    /// </summary>
    public class IntermediateDespesa : IntermediateBaseEntity
    {
        /// <summary>
        /// The Descricao property.
        /// </summary>
        public string Descricao { get;set;} = string.Empty;

        /// <summary>
        /// The Valor property.
        /// </summary>
        public decimal Valor { get;set;}

        /// <summary>
        /// The Local property.
        /// </summary>
        public string Local { get;set;} = string.Empty;
    }
}

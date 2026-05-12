#region Usings
using Backend.Domain.Models.Entity; 
#endregion Usings

namespace Backend.Domain.Models
{
    /// <summary>
    /// The IntermediateCompromissoModel class.
    /// </summary>
    public class IntermediateCompromissoModel : IntermediateCompromisso
    {
        /// <summary>
        /// The IsEdit property.
        /// </summary>
        public bool IsEdit { get; set; }
    }
}

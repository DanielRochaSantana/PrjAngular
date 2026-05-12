#region Usings
using Backend.Domain.Models.Entity;
#endregion Usings

namespace Backend.Domain.Models
{
    /// <summary>
    /// The IntermediateAtividadeModel class.
    /// </summary>
    public class IntermediateAtividadeModel : IntermediateAtividade
    {
        /// <summary>
        /// The IsEdit property.
        /// </summary>
        public bool IsEdit { get; set; }
    }
}

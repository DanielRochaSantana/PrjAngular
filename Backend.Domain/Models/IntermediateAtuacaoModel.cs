#region Usings
using Backend.Domain.Models.Entity;
#endregion Usings

namespace Backend.Domain.Models
{
    /// <summary>
    /// The IntermediateAtuacaoModel class.
    /// </summary>
    public class IntermediateAtuacaoModel : IntermediateAtuacao
    {
        /// <summary>
        /// The IsEdit property.
        /// </summary>
        public bool IsEdit { get; set; }
    }
}

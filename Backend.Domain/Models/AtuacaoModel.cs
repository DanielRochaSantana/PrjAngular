#region Usings
using Backend.Domain.Models.Entity; 
#endregion Usings

namespace Backend.Domain.Models
{
    /// <summary>
    /// The AtuacaoModel class.
    /// </summary>
    public class AtuacaoModel : Atuacao
    {
        /// <summary>
        /// The IsEdit property.
        /// </summary>
        public bool IsEdit { get; set; }
    }
}

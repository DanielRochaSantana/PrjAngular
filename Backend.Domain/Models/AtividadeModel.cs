#region Usings
using Backend.Domain.Models.Entity;
#endregion Usings

namespace Backend.Domain.Models
{
    /// <summary>
    /// The AtividadeModel class.
    /// </summary>
    public class AtividadeModel : Atividade
    {
        /// <summary>
        /// The IsEdit property.
        /// </summary>
        public bool IsEdit { get; set; }
    }
}

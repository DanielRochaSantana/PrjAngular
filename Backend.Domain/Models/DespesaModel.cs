#region Usings
using Backend.Domain.Models.Entity;      
#endregion Usings

namespace Backend.Domain.Models
{
    /// <summary>
    /// The DespesaModel class.          
    /// </summary>
    public class DespesaModel : Despesa
    {
        /// <summary>
        /// The IsEdit property.
        /// </summary>
        public bool IsEdit { get; set; }
    }
}

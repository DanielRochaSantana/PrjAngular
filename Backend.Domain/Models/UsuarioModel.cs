#region Usings
using Backend.Domain.Models.Entity; 
#endregion Usings

namespace Backend.Domain.Models
{
    /// <summary>
    /// The UsuarioModel class.
    /// </summary>
    public class UsuarioModel : Usuario
    {
        /// <summary>
        /// The IsEdit property.
        /// </summary>
        public bool IsEdit { get; set; }
    }
}

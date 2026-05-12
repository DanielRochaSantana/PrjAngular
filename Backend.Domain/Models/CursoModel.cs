#region Usings
using Backend.Domain.Models.Entity; 
#endregion Usings

namespace Backend.Domain.Models
{
    /// <summary>
    /// The CursoModel class that descends from Curso.
    /// </summary>
    public class CursoModel : Curso
    {
        /// <summary>
        /// The IsEdit property.
        /// </summary>
        public bool IsEdit { get; set; }
    }
}

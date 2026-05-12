#region Usings
using Backend.Domain.Models.Entity; 
#endregion Usings

namespace Backend.Domain.Models
{
    /// <summary>
    /// The IntermediateCursoModel class that descends from IntermediateCurso.
    /// </summary>
    public class IntermediateCursoModel : IntermediateCurso
    {
        /// <summary>
        /// The IsEdit property.
        /// </summary>
        public bool IsEdit { get; set; }
    }
}
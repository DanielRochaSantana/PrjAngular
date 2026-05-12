#region Usings
using Backend.Domain.Models.Base; 
#endregion Usings

namespace Backend.Domain.Models.Entity
{
    /// <summary>
    /// The Atividade class.
    /// </summary>
    public class Atividade : BaseEntity
    {
        /// <summary>
        /// The Descricao property.
        /// </summary>
        public string Descricao { get;set;} = string.Empty;

        /// <summary>
        /// The Horario property.
        /// </summary>
        public string Horario { get;set;} = string.Empty;

        /// <summary>
        /// The Local property.
        /// </summary>
        public string Local { get;set;} = string.Empty;
    }
}

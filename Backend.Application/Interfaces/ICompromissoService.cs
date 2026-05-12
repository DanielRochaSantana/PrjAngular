#region Usings
using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;
#endregion Usings

namespace Backend.Application.Interfaces
{
    /// <summary>
    /// The ICompromissoService interface.
    /// </summary>
    public interface ICompromissoService
    {
        #region CommandSide
        /// <summary>
        /// Contrato para haver a adição de registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        void Adicionar(Compromisso registro, string propriedadeChave, string tableName);

        /// <summary>
        /// Contrato para haver a atualização de registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        void Atualizar(Compromisso registro, string propriedadeChave, string tableName);

        /// <summary>
        /// Contrato para haver a remoção de registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        void Remover(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave);
        #endregion CommandSide

        #region QuerySide
        /// <summary>
        /// Contrato para haver a listragem de registro.
        /// </summary>
        /// <param name="tableName">The tableName parameter.</param>
        /// <returns>IEnumerable of Compromisso.</returns>
        IEnumerable<Compromisso> ListarRegistros(string tableName);

        /// <summary>
        /// Contrato para haver a obtenção de registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <returns>Compromisso.</returns>
        Compromisso? EncontrarPorCodigo(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave);
        #endregion QuerySide
    }
}

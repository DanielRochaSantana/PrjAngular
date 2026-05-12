#region Usings
using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;
#endregion Usings

namespace Backend.Application.Interfaces
{
    /// <summary>
    /// The ICursoService interface.
    /// </summary>
    public interface ICursoService
    {
        #region CommandSide
        /// <summary>
        /// Contrato para a adição de registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        void Adicionar(Curso registro, string propriedadeChave, string tableName);

        /// <summary>
        /// Contrato para a atualização de registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        void Atualizar(Curso registro, string propriedadeChave, string tableName);

        /// <summary>
        /// Contrato para a remoção de registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        void Remover(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave);
        #endregion CommandSide

        #region QuerySide
        /// <summary>
        /// Contrato para a listagem de registros.
        /// </summary>
        /// <param name="tableName">The tableName parameter.</param>
        /// <returns>IEnumerable of Curso.</returns>
        IEnumerable<Curso> ListarRegistros(string tableName);

        /// <summary>
        /// Contrato para a obtenção de registro
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <returns>Curso.</returns>
        Curso? EncontrarPorCodigo(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave);
        #endregion QuerySide
    }
}
#region Usings
using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;
#endregion Usings

namespace Backend.Application.Interfaces
{
    /// <summary>
    /// The IAtividadeService interface.
    /// </summary>
    public interface IAtividadeService
    {
        #region CommandSide
        /// <summary>
        /// Contrato para haver a adição de registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        void Adicionar(Atividade registro, string propriedadeChave, string tableName);

        /// <summary>
        /// Contrato para haver a atualização de registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        void Atualizar(Atividade registro, string propriedadeChave, string tableName);

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
        /// Contrato para haver a listagem de registros.
        /// </summary>
        /// <param name="tableName">The tableName parameter.</param>
        /// <returns>IEnumerable of Atividade.</returns>
        IEnumerable<Atividade> ListarRegistros(string tableName);

        /// <summary>
        /// Contrato para haver a obtenção de registro por Id.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <returns>Atividade.</returns>
        Atividade? EncontrarPorCodigo(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave);
        #endregion QuerySide
    }
}
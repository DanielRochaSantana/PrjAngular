#region Usings
using Backend.Application.Interfaces;
using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;
using Backend.Infrastructure.Interfaces.CommandSide;
using Backend.Infrastructure.Interfaces.QuerySide;
#endregion Usings

namespace Backend.Application.Services
{
    /// <summary>
    /// The AtividadeService service.
    /// </summary>
    public class AtividadeService : IAtividadeService
    {
        #region Service Fields
        /// <summary>
        /// The _repositorioAtividade field.
        /// </summary>
        protected readonly IRepositorioGenerico<Atividade> _repositorioAtividade;

        /// <summary>
        /// The _consultaAtividade field.
        /// </summary>
        protected readonly IConsultaGenerica<Atividade> _consultaAtividade;
        #endregion Service Fields

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositorioAtividade">The repositorioAtividade parameter.</param>
        /// <param name="consultaAtividade">The consultaAtividade parameter.</param>
        public AtividadeService(IRepositorioGenerico<Atividade> repositorioAtividade,
                                IConsultaGenerica<Atividade> consultaAtividade)
        {
            _repositorioAtividade = repositorioAtividade;
            _consultaAtividade = consultaAtividade;
        }
        #endregion Constructor

        #region CommandSide
        /// <summary>
        /// Efetua a adição de um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        public void Adicionar(Atividade registro, string propriedadeChave, string tableName)
        {
            _repositorioAtividade.Adicionar(registro, propriedadeChave, tableName);
        }

        /// <summary>
        /// Efetua a atualização de um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        public void Atualizar(Atividade registro, string propriedadeChave, string tableName)
        {
            _repositorioAtividade.Atualizar(registro, propriedadeChave, tableName);
        }

        /// <summary>
        /// Efetua a remoção de um registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        public void Remover(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave)
        {
            _repositorioAtividade.Remover(id, entityEnum, tableName, propriedadeChave);
        }
        #endregion CommandSide

        #region QuerySide
        /// <summary>
        /// Efetua a listagem de registros.
        /// </summary>
        /// <param name="tableName">The tableName parameter.</param>
        /// <returns>IEnumerable of Atividade.</returns>
        public IEnumerable<Atividade> ListarRegistros(string tableName)
        {
            return _consultaAtividade.ListarRegistros(tableName);
        }

        /// <summary>
        /// Efetua a obtenção de um registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <returns>Atividade.</returns>
        public Atividade? EncontrarPorCodigo(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave)
        {
            return _consultaAtividade.EncontrarPorId(id, entityEnum, tableName, propriedadeChave);
        }
        #endregion QuerySide
    }
}

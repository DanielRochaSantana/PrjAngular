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
    /// The AtuacaoService service.
    /// </summary>
    public class AtuacaoService : IAtuacaoService
    {
        #region Service Fields
        /// <summary>
        /// The _repositorioAtuacao field.
        /// </summary>
        protected readonly IRepositorioGenerico<Atuacao> _repositorioAtuacao;

        /// <summary>
        /// The _consultaAtuacao field.
        /// </summary>
        protected readonly IConsultaGenerica<Atuacao> _consultaAtuacao;
        #endregion Service Fields

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositorioAtuacao">The repositorioAtuacao parameter.</param>
        /// <param name="consultaAtuacao">The consultaAtuacao parameter.</param>
        public AtuacaoService(IRepositorioGenerico<Atuacao> repositorioAtuacao,
                              IConsultaGenerica<Atuacao> consultaAtuacao)
        {
            _repositorioAtuacao = repositorioAtuacao;
            _consultaAtuacao = consultaAtuacao;
        }
        #endregion Constructor

        #region CommandSide
        /// <summary>
        /// Efetua a adição de um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        public void Adicionar(Atuacao registro, string propriedadeChave, string tableName)
        {
            _repositorioAtuacao.Adicionar(registro, propriedadeChave, tableName);
        }

        /// <summary>
        /// Efetua a atualização de um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        public void Atualizar(Atuacao registro, string propriedadeChave, string tableName)
        {
            _repositorioAtuacao.Atualizar(registro, propriedadeChave, tableName);
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
            _repositorioAtuacao.Remover(id, entityEnum, tableName, propriedadeChave);
        }
        #endregion CommandSide

        #region QuerySide
        /// <summary>
        /// Efetua a listagem de registros.
        /// </summary>
        /// <param name="tableName">The tableName parameter.</param>
        /// <returns>IEnumerable of Atuacao.</returns>
        public IEnumerable<Atuacao> ListarRegistros(string tableName)
        {
            return _consultaAtuacao.ListarRegistros(tableName);
        }

        /// <summary>
        /// Efetua a obtenção de um registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <returns>Atuacao.</returns>
        public Atuacao? EncontrarPorCodigo(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave)
        {
            return _consultaAtuacao.EncontrarPorId(id, entityEnum, tableName, propriedadeChave);
        }
        #endregion QuerySide
    }
}

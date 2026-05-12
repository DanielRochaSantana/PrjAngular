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
    /// The CompromissoService service.
    /// </summary>
    public class CompromissoService : ICompromissoService
    {
        #region Service Fields
        /// <summary>
        /// The _repositorioCompromisso field.
        /// </summary>
        protected readonly IRepositorioGenerico<Compromisso> _repositorioCompromisso;

        /// <summary>
        /// The _consultaCompromisso field.
        /// </summary>
        protected readonly IConsultaGenerica<Compromisso> _consultaCompromisso;
        #endregion Service Fields

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositorioCompromisso">The repositorioCompromisso parameter.</param>
        /// <param name="consultaCompromisso">The consultaCompromisso parameter.</param>
        public CompromissoService(IRepositorioGenerico<Compromisso> repositorioCompromisso,
                              IConsultaGenerica<Compromisso> consultaCompromisso)
        {
            _repositorioCompromisso = repositorioCompromisso;
            _consultaCompromisso = consultaCompromisso;
        }
        #endregion Constructor

        #region CommandSide
        /// <summary>
        /// Efetua a adição de um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        public void Adicionar(Compromisso registro, string propriedadeChave, string tableName)
        {
            _repositorioCompromisso.Adicionar(registro, propriedadeChave, tableName);
        }

        /// <summary>
        /// Efetua a atualização de um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        public void Atualizar(Compromisso registro, string propriedadeChave, string tableName)
        {
            _repositorioCompromisso.Atualizar(registro, propriedadeChave, tableName);
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
            _repositorioCompromisso.Remover(id, entityEnum, tableName, propriedadeChave);
        }
        #endregion CommandSide

        #region QuerySide
        /// <summary>
        /// Efetua a listagem de registros.
        /// </summary>
        /// <param name="tableName">The tableName parameter.</param>
        /// <returns>IEnumerable of Compromisso.</returns>
        public IEnumerable<Compromisso> ListarRegistros(string tableName)
        {
            return _consultaCompromisso.ListarRegistros(tableName);
        }

        /// <summary>
        /// Efetua a obtenção de um registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <returns>Compromisso.</returns>
        public Compromisso? EncontrarPorCodigo(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave)
        {
            return _consultaCompromisso.EncontrarPorId(id, entityEnum, tableName, propriedadeChave);
        }
        #endregion QuerySide
    }
}

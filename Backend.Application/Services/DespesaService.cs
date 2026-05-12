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
    /// The DespesaService interface.
    /// </summary>
    public class DespesaService : IDespesaService
    {
        #region Service Fields        
        /// <summary>
        /// The _repositorioDespesa field.
        /// </summary>
        protected readonly IRepositorioGenerico<Despesa> _repositorioDespesa;

        /// <summary>
        /// The _consultaDespesa field.
        /// </summary>
        protected readonly IConsultaGenerica<Despesa> _consultaDespesa;
        #endregion Service Fields

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositorioDespesa">The repositorioDespesa parameter.</param>
        /// <param name="consultaDespesa">The consultaDespesa parameter.</param>
        public DespesaService(IRepositorioGenerico<Despesa> repositorioDespesa,
                              IConsultaGenerica<Despesa> consultaDespesa)
        {
            _repositorioDespesa = repositorioDespesa;
            _consultaDespesa = consultaDespesa;
        }
        #endregion Constructor

        #region CommandSide
        /// <summary>
        /// Efetua a adição de um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        public void Adicionar(Despesa registro, string propriedadeChave, string tableName)
        {
            _repositorioDespesa.Adicionar(registro, propriedadeChave, tableName);
        }

        /// <summary>
        /// Efetua a atualização de um registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        public void Atualizar(Despesa registro, string propriedadeChave, string tableName)
        {
            _repositorioDespesa.Atualizar(registro, propriedadeChave, tableName);
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
            _repositorioDespesa.Remover(id, entityEnum, tableName, propriedadeChave);
        }
        #endregion CommandSide

        #region QuerySide
        /// <summary>
        /// Efetua a listagem de registros.
        /// </summary>
        /// <param name="tableName">The tableName parameter.</param>
        /// <returns>IEnumerable of Despesa.</returns>
        public IEnumerable<Despesa> ListarRegistros(string tableName)
        {
            return _consultaDespesa.ListarRegistros(tableName);
        }

        /// <summary>
        /// Efetua a obtenção de um registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <returns>Despesa.</returns>
        public Despesa? EncontrarPorCodigo(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave)
        {
            return _consultaDespesa.EncontrarPorId(id, entityEnum, tableName, propriedadeChave);
        }
        #endregion QuerySide
    }
}

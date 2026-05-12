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
    /// The CursoService class that implements the ICursoService's contracts.
    /// </summary>
    public class CursoService : ICursoService
    {
        #region Service Fields
        /// <summary>
        /// The _repositorioCurso field.
        /// </summary>
        protected readonly IRepositorioGenerico<Curso> _repositorioCurso;

        /// <summary>
        /// The _consultaCurso field.
        /// </summary>
        protected readonly IConsultaGenerica<Curso> _consultaCurso;
        #endregion Service Fields

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositorioCurso">The repositorioCurso parameter.</param>
        /// <param name="consultaCurso">The consultaCurso parameter.</param>
        public CursoService(IRepositorioGenerico<Curso> repositorioCurso,
                              IConsultaGenerica<Curso> consultaCurso)
        {
            _repositorioCurso = repositorioCurso;
            _consultaCurso = consultaCurso;
        } 
        #endregion Constructor

        #region CommandSide
        /// <summary>
        /// Efetua a adição de registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        public void Adicionar(Curso registro, string propriedadeChave, string tableName)
        {
            _repositorioCurso.Adicionar(registro, propriedadeChave, tableName);
        }

        /// <summary>
        /// Efetua a atualização de registro.
        /// </summary>
        /// <param name="registro">The registro parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        public void Atualizar(Curso registro, string propriedadeChave, string tableName)
        {
            _repositorioCurso.Atualizar(registro, propriedadeChave, tableName);
        }

        /// <summary>
        /// Efetua a remoção de registro.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        public void Remover(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave)
        {
            _repositorioCurso.Remover(id, entityEnum, tableName, propriedadeChave);
        }
        #endregion CommandSide

        #region QuerySide
        /// <summary>
        /// Efetua a listagem de registros.
        /// </summary>
        /// <param name="tableName">The tableName parameter.</param>
        /// <returns>IEnumerable of Curso.</returns>
        public IEnumerable<Curso> ListarRegistros(string tableName)
        {
            return _consultaCurso.ListarRegistros(tableName);
        }

        /// <summary>
        /// Efetua a obtenção de registro por Id.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="tableName">The tableName parameter.</param>
        /// <param name="propriedadeChave">The propriedadeChave parameter.</param>
        /// <returns>Curso.</returns>
        public Curso? EncontrarPorCodigo(Guid id, ObjectFactory.EntityEnum entityEnum, string tableName, string propriedadeChave)
        {
            return _consultaCurso.EncontrarPorId(id, entityEnum, tableName, propriedadeChave);
        }
        #endregion QuerySide
    }
}

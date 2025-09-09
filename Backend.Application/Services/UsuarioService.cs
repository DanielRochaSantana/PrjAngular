using Backend.Application.Interfaces;
using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;
using Backend.Infrastructure.Interfaces.CommandSide;
using Backend.Infrastructure.Interfaces.QuerySide;

namespace Backend.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        protected readonly IRepositorioGenerico<Usuario> _repositorioUsuario;
        protected readonly IConsultaGenerica<Usuario> _consultaUsuario;

        public UsuarioService(IRepositorioGenerico<Usuario> repositorioUsuario,
                              IConsultaGenerica<Usuario> consultaUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
            _consultaUsuario = consultaUsuario;
        }

        #region CommandSide
        public void Adicionar(Usuario registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioUsuario.Adicionar(registro, sPropriedadeChave, sTableName);
        }

        public void Atualizar(Usuario registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioUsuario.Atualizar(registro, sPropriedadeChave, sTableName);
        }

        public void Remover(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            _repositorioUsuario.Remover(Id, entityEnum, sTableName, sPropriedadeChave);
        }        
        #endregion CommandSide

        #region QuerySide
        public IEnumerable<Usuario> ListarRegistros(string sTableName)
        {
            return _consultaUsuario.ListarRegistros(sTableName);
        }

        public Usuario? EncontrarPorCodigo(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            return _consultaUsuario.EncontrarPorCodigo(Id, entityEnum, sTableName, sPropriedadeChave);
        }        
        #endregion QuerySide
    }
}

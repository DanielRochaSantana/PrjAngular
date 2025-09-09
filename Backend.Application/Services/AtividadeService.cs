using Backend.Application.Interfaces;
using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;
using Backend.Infrastructure.Interfaces.CommandSide;
using Backend.Infrastructure.Interfaces.QuerySide;

namespace Backend.Application.Services
{
    public class AtividadeService : IAtividadeService
    {
        protected readonly IRepositorioGenerico<Atividade> _repositorioAtividade;
        protected readonly IConsultaGenerica<Atividade> _consultaAtividade;

        public AtividadeService(IRepositorioGenerico<Atividade> repositorioAtividade,
                              IConsultaGenerica<Atividade> consultaAtividade)
        {
            _repositorioAtividade = repositorioAtividade;
            _consultaAtividade = consultaAtividade;
        }

        #region CommandSide
        public void Adicionar(Atividade registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioAtividade.Adicionar(registro, sPropriedadeChave, sTableName);
        }

        public void Atualizar(Atividade registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioAtividade.Atualizar(registro, sPropriedadeChave, sTableName);
        }

        public void Remover(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            _repositorioAtividade.Remover(Id, entityEnum, sTableName, sPropriedadeChave);
        }        
        #endregion CommandSide

        #region QuerySide
        public IEnumerable<Atividade> ListarRegistros(string sTableName)
        {
            return _consultaAtividade.ListarRegistros(sTableName);
        }

        public Atividade? EncontrarPorCodigo(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            return _consultaAtividade.EncontrarPorCodigo(Id, entityEnum, sTableName, sPropriedadeChave);
        }        
        #endregion QuerySide
    }
}

using Backend.Application.Interfaces;
using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;
using Backend.Infrastructure.Interfaces.CommandSide;
using Backend.Infrastructure.Interfaces.QuerySide;

namespace Backend.Application.Services
{
    public class AtuacaoService : IAtuacaoService
    {
        protected readonly IRepositorioGenerico<Atuacao> _repositorioAtuacao;
        protected readonly IConsultaGenerica<Atuacao> _consultaAtuacao;

        public AtuacaoService(IRepositorioGenerico<Atuacao> repositorioAtuacao,
                              IConsultaGenerica<Atuacao> consultaAtuacao)
        {
            _repositorioAtuacao = repositorioAtuacao;
            _consultaAtuacao = consultaAtuacao;
        }

        #region CommandSide
        public void Adicionar(Atuacao registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioAtuacao.Adicionar(registro, sPropriedadeChave, sTableName);
        }

        public void Atualizar(Atuacao registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioAtuacao.Atualizar(registro, sPropriedadeChave, sTableName);
        }

        public void Remover(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            _repositorioAtuacao.Remover(Id, entityEnum, sTableName, sPropriedadeChave);
        }        
        #endregion CommandSide

        #region QuerySide
        public IEnumerable<Atuacao> ListarRegistros(string sTableName)
        {
            return _consultaAtuacao.ListarRegistros(sTableName);
        }

        public Atuacao? EncontrarPorCodigo(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            return _consultaAtuacao.EncontrarPorCodigo(Id, entityEnum, sTableName, sPropriedadeChave);
        }        
        #endregion QuerySide
    }
}

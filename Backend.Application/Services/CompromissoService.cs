using Backend.Application.Interfaces;
using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;
using Backend.Infrastructure.Interfaces.CommandSide;
using Backend.Infrastructure.Interfaces.QuerySide;

namespace Backend.Application.Services
{
    public class CompromissoService : ICompromissoService
    {
        protected readonly IRepositorioGenerico<Compromisso> _repositorioCompromisso;
        protected readonly IConsultaGenerica<Compromisso> _consultaCompromisso;
        
        public CompromissoService(IRepositorioGenerico<Compromisso> repositorioCompromisso,
                              IConsultaGenerica<Compromisso> consultaCompromisso)
        {
            _repositorioCompromisso = repositorioCompromisso;
            _consultaCompromisso = consultaCompromisso;
        }

        #region CommandSide
        public void Adicionar(Compromisso registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioCompromisso.Adicionar(registro, sPropriedadeChave, sTableName);
        }

        public void Atualizar(Compromisso registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioCompromisso.Atualizar(registro, sPropriedadeChave, sTableName);
        }

        public void Remover(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            _repositorioCompromisso.Remover(Id, entityEnum, sTableName, sPropriedadeChave);
        }
        #endregion CommandSide

        #region QuerySide
        public IEnumerable<Compromisso> ListarRegistros(string sTableName)
        {
            return _consultaCompromisso.ListarRegistros(sTableName);
        }

        public Compromisso? EncontrarPorCodigo(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            return _consultaCompromisso.EncontrarPorCodigo(Id, entityEnum, sTableName, sPropriedadeChave);
        }
        #endregion QuerySide
    }
}

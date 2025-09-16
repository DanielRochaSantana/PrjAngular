using Backend.Application.Interfaces;
using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;
using Backend.Infrastructure.Interfaces.CommandSide;
using Backend.Infrastructure.Interfaces.QuerySide;

namespace Backend.Application.Services
{
    public class DespesaService : IDespesaService
    {
        protected readonly IRepositorioGenerico<Despesa> _repositorioDespesa;
        protected readonly IConsultaGenerica<Despesa> _consultaDespesa;

        public DespesaService(IRepositorioGenerico<Despesa> repositorioDespesa,
                              IConsultaGenerica<Despesa> consultaDespesa)
        {
            _repositorioDespesa = repositorioDespesa;
            _consultaDespesa = consultaDespesa;
        }

        #region CommandSide
        public void Adicionar(Despesa registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioDespesa.Adicionar(registro, sPropriedadeChave, sTableName);
        }

        public void Atualizar(Despesa registro, string sPropriedadeChave, string sTableName)
        {
            _repositorioDespesa.Atualizar(registro, sPropriedadeChave, sTableName);
        }

        public void Remover(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            _repositorioDespesa.Remover(Id, entityEnum, sTableName, sPropriedadeChave);
        }        
        #endregion CommandSide

        #region QuerySide
        public IEnumerable<Despesa> ListarRegistros(string sTableName)
        {
            return _consultaDespesa.ListarRegistros(sTableName);
        }

        public Despesa? EncontrarPorCodigo(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave)
        {
            return _consultaDespesa.EncontrarPorCodigo(Id, entityEnum, sTableName, sPropriedadeChave);
        }        
        #endregion QuerySide
    }
}

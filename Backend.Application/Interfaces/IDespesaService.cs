using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;

namespace Backend.Application.Interfaces
{
    public interface IDespesaService
    {
        #region CommandSide
        public void Adicionar(Despesa registro, string sPropriedadeChave, string sTableName);
        public void Atualizar(Despesa registro, string sPropriedadeChave, string sTableName);
        public void Remover(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        #endregion CommandSide

        #region QuerySide
        public IEnumerable<Despesa> ListarRegistros(string sTableName);
        public Despesa? EncontrarPorCodigo(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        #endregion QuerySide
    }
}

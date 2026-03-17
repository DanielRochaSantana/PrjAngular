using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;

namespace Backend.Application.Interfaces
{
    public interface ICompromissoService
    {
        #region CommandSide
        public void Adicionar(Compromisso registro, string sPropriedadeChave, string sTableName);
        public void Atualizar(Compromisso registro, string sPropriedadeChave, string sTableName);
        public void Remover(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        #endregion CommandSide

        #region QuerySide
        public IEnumerable<Compromisso> ListarRegistros(string sTableName);
        public Compromisso? EncontrarPorCodigo(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        #endregion QuerySide
    }
}

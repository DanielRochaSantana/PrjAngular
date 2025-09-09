using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;

namespace Backend.Application.Interfaces
{
    public interface IAtividadeService
    {
        #region CommandSide
        public void Adicionar(Atividade registro, string sPropriedadeChave, string sTableName);
        public void Atualizar(Atividade registro, string sPropriedadeChave, string sTableName);
        public void Remover(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        #endregion CommandSide

        #region QuerySide
        public IEnumerable<Atividade> ListarRegistros(string sTableName);
        public Atividade? EncontrarPorCodigo(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        #endregion QuerySide
    }
}

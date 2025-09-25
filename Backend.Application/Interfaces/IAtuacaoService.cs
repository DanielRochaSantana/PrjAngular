using Backend.Domain.Models.Entity;
using Backend.Infrastructure.Factory;

namespace Backend.Application.Interfaces
{
    public interface IAtuacaoService
    {
        #region CommandSide
        public void Adicionar(Atuacao registro, string sPropriedadeChave, string sTableName);
        public void Atualizar(Atuacao registro, string sPropriedadeChave, string sTableName);
        public void Remover(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        #endregion CommandSide

        #region QuerySide
        public IEnumerable<Atuacao> ListarRegistros(string sTableName);
        public Atuacao? EncontrarPorCodigo(Guid Id, ObjectFactory.EntityEnum entityEnum, string sTableName, string sPropriedadeChave);
        #endregion QuerySide
    }
}

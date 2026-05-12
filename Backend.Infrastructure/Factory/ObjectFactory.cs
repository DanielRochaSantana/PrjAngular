#region Usings
using Backend.Domain.Models;
using Backend.Domain.Models.Entity;
#endregion Usings

namespace Backend.Infrastructure.Factory
{
    /// <summary>
    /// The ObjectFactory class.
    /// </summary>
    public static class ObjectFactory
    {
        /// <summary>
        /// Obtem uma nova instância de objeto.
        /// </summary>
        /// <param name="entityEnum">The entityEnum parameter.</param>
        /// <param name="id">The id parameter.</param>
        /// <returns>object.</returns>
        public static object GetObject(EntityEnum entityEnum, Guid id)
        {
            switch (entityEnum)
            {
                case EntityEnum.Usuario:
                    return new Usuario { Id = id };
                case EntityEnum.Atividade:
                    return new Atividade { Id = id };
                case EntityEnum.Despesa:
                    return new Despesa { Id = id };
                case EntityEnum.Atuacao:
                    return new Atuacao { Id = id };
                case EntityEnum.Compromisso:
                    return new Compromisso { Id = id };
                case EntityEnum.Curso:
                    return new Curso { Id = id };
                default:
                    return new();
            }
        }

        /// <summary>
        /// Obtem uma nova instância de objeto.
        /// </summary>
        /// <param name="objEnum">The objEnum parameter.</param>
        /// <returns>object.</returns>
        public static object GetInstance(ObjectEnum objEnum)
        {
            switch (objEnum)
            {
                case ObjectEnum.ListaStrings:
                    return new List<string>();
                default:
                    return new();
            }
        }

        /// <summary>
        /// Obtem um objeto Usuario à partir do parâmetro de entrada do tipo UsuarioModel.
        /// </summary>
        /// <param name="usuarioModel">The usuarioModel parameter.</param>
        /// <returns>Usuario.</returns>
        public static Usuario GetUsuarioFromUsuarioModel(UsuarioModel? usuarioModel)
        {
            if (usuarioModel != null)
                return new Usuario
                {
                    Celular = usuarioModel.Celular,
                    DataCadastro = usuarioModel.DataCadastro,
                    DataModificacao = usuarioModel.DataModificacao,
                    Email = usuarioModel.Email,
                    Id = usuarioModel.Id,
                    IsAtivo = usuarioModel.IsAtivo,
                    Nome = usuarioModel.Nome
                };

            return new();
        }

        /// <summary>
        /// Obtem um objeto Atividade à partir de um objeto do tipo AtividadeModel.
        /// </summary>
        /// <param name="atividadeModel">The AtividadeModel parameter.</param>
        /// <returns>Atividade.</returns>
        public static Atividade GetAtividadeFromAtividadeModel(AtividadeModel? atividadeModel)
        {
            if (atividadeModel != null)
                return new Atividade
                {
                    Local = atividadeModel.Local,
                    DataCadastro = atividadeModel.DataCadastro,
                    DataModificacao = atividadeModel.DataModificacao,
                    Horario = atividadeModel.Horario,
                    Id = atividadeModel.Id,
                    IsAtivo = atividadeModel.IsAtivo,
                    Descricao = atividadeModel.Descricao
                };

            return new();
        }

        /// <summary>
        /// Obtem um objeto Despesa à partir de um objeto do tipo DespesaModel.
        /// </summary>
        /// <param name="despesaModel">The DespesaModel parameter.</param>
        /// <returns>Despesa.</returns>
        public static Despesa GetDespesaFromDespesaModel(DespesaModel? despesaModel)
        {
            if (despesaModel != null)
                return new Despesa
                {
                    Local = despesaModel.Local,
                    DataCadastro = despesaModel.DataCadastro,
                    DataModificacao = despesaModel.DataModificacao,
                    Valor = despesaModel.Valor,
                    Id = despesaModel.Id,
                    IsAtivo = despesaModel.IsAtivo,
                    Descricao = despesaModel.Descricao
                };

            return new();
        }

        /// <summary>
        /// Obtem um objeto Atuacao à partir de um objeto do tipo AtuacaoModel.
        /// </summary>
        /// <param name="atuacaoModel">The AtuacaoModel parameter.</param>
        /// <returns>Atuacao.</returns>
        public static Atuacao GetAtuacaoFromAtuacaoModel(AtuacaoModel? atuacaoModel)
        {
            if (atuacaoModel != null)
                return new Atuacao
                {
                    Local = atuacaoModel.Local,
                    DataCadastro = atuacaoModel.DataCadastro,
                    DataModificacao = atuacaoModel.DataModificacao,
                    Empresa = atuacaoModel.Empresa,
                    Id = atuacaoModel.Id,
                    IsAtivo = atuacaoModel.IsAtivo,
                    Descricao = atuacaoModel.Descricao
                };

            return new();
        }

        /// <summary>
        /// Obtem um objeto Compromisso à partir de um objeto do tipo CompromissoModel.
        /// </summary>
        /// <param name="compromissoModel">The CompromissoModel parameter.</param>
        /// <returns>Compromisso.</returns>
        public static Compromisso GetCompromissoFromCompromissoModel(CompromissoModel? compromissoModel)
        {
            if (compromissoModel != null)
                return new Compromisso
                {
                    Local = compromissoModel.Local,
                    DataCadastro = compromissoModel.DataCadastro,
                    DataModificacao = compromissoModel.DataModificacao,
                    HoraInicio = compromissoModel.HoraInicio,
                    Id = compromissoModel.Id,
                    IsAtivo = compromissoModel.IsAtivo,
                    Descricao = compromissoModel.Descricao
                };

            return new();
        }

        /// <summary>
        /// Obtem um objeto Curso à partir de um objeto do tipo CursoModel.
        /// </summary>
        /// <param name="cursoModel">The CursoModel parameter.</param>
        /// <returns>Curso.</returns>
        public static Curso GetCursoFromCursoModel(CursoModel? cursoModel)
        {
            if (cursoModel != null)
                return new Curso
                {
                    Id = cursoModel.Id,
                    Descricao = cursoModel.Descricao,
                    Instituicao = cursoModel.Instituicao,
                    Local = cursoModel.Local,
                    DataCadastro = cursoModel.DataCadastro,
                    DataModificacao = cursoModel.DataModificacao,
                    IsAtivo = cursoModel.IsAtivo,
                };

            return new();
        }

        /// <summary>
        /// Obtem um objeto Usuario à partir de um objeto do tipo IntermediateUsuarioModel.
        /// </summary>
        /// <param name="intermediateUsuarioModel">The IntermediateUsuarioModel parameter.</param>
        /// <returns>Usuario.</returns>
        public static Usuario GetUsuarioFromIntermediateUsuarioModel(IntermediateUsuarioModel? intermediateUsuarioModel)
        {
            Guid _id = Guid.Empty;

            if (intermediateUsuarioModel != null && intermediateUsuarioModel.Id != Guid.Empty.ToString())
                Guid.TryParse(intermediateUsuarioModel.Id, out _id);

            if (_id == Guid.Empty)
                _id = Guid.NewGuid();

            if (intermediateUsuarioModel != null)
                return new Usuario
                {
                    Celular = intermediateUsuarioModel.Celular,
                    DataCadastro = intermediateUsuarioModel.DataCadastro,
                    DataModificacao = intermediateUsuarioModel.DataModificacao,
                    Email = intermediateUsuarioModel.Email,
                    Id = _id,
                    IsAtivo = intermediateUsuarioModel.IsAtivo,
                    Nome = intermediateUsuarioModel.Nome
                };

            return new();
        }

        /// <summary>
        /// Obtem um objeto Atividade à partir de um objeto do tipo IntermediateAtividadeModel.
        /// </summary>
        /// <param name="intermediateAtividadeModel">The IntermediateAtividadeModel parameter.</param>
        /// <returns>Atividade.</returns>
        public static Atividade GetAtividadeFromIntermediateAtividadeModel(IntermediateAtividadeModel? intermediateAtividadeModel)
        {
            Guid _id = Guid.Empty;

            if (intermediateAtividadeModel != null && intermediateAtividadeModel.Id != Guid.Empty.ToString())
                Guid.TryParse(intermediateAtividadeModel.Id, out _id);

            if (_id == Guid.Empty)
                _id = Guid.NewGuid();

            if (intermediateAtividadeModel != null)
                return new Atividade
                {
                    Local = intermediateAtividadeModel.Local,
                    DataCadastro = intermediateAtividadeModel.DataCadastro,
                    DataModificacao = intermediateAtividadeModel.DataModificacao,
                    Horario = intermediateAtividadeModel.Horario,
                    Id = _id,
                    IsAtivo = intermediateAtividadeModel.IsAtivo,
                    Descricao = intermediateAtividadeModel.Descricao
                };

            return new();
        }

        /// <summary>
        /// Obtem um objeto Despesa à partir de um objeto do tipo IntermediateDespesaModel.
        /// </summary>
        /// <param name="intermediateDespesaModel">The IntermediateDespesaModel parameter.</param>
        /// <returns>Despesa.</returns>
        public static Despesa GetDespesaFromIntermediateDespesaModel(IntermediateDespesaModel? intermediateDespesaModel)
        {
            Guid _id = Guid.Empty;

            if (intermediateDespesaModel != null && intermediateDespesaModel.Id != Guid.Empty.ToString())
                Guid.TryParse(intermediateDespesaModel.Id, out _id);

            if (_id == Guid.Empty)
                _id = Guid.NewGuid();

            if (intermediateDespesaModel != null)
                return new Despesa
                {
                    Local = intermediateDespesaModel.Local,
                    DataCadastro = intermediateDespesaModel.DataCadastro,
                    DataModificacao = intermediateDespesaModel.DataModificacao,
                    Valor = intermediateDespesaModel.Valor,
                    Id = _id,
                    IsAtivo = intermediateDespesaModel.IsAtivo,
                    Descricao = intermediateDespesaModel.Descricao
                };

            return new();
        }

        /// <summary>
        /// Obtem um objeto Atuacao à partir de um objeto do tipo IntermediateAtuacaoModel.
        /// </summary>
        /// <param name="intermediateAtuacaoModel">The IntermediateAtuacaoModel parameter.</param>
        /// <returns>Atuacao.</returns>
        public static Atuacao GetAtuacaoFromIntermediateAtuacaoModel(IntermediateAtuacaoModel? intermediateAtuacaoModel)
        {
            Guid _id = Guid.Empty;

            if (intermediateAtuacaoModel != null && intermediateAtuacaoModel.Id != Guid.Empty.ToString())
                Guid.TryParse(intermediateAtuacaoModel.Id, out _id);

            if (_id == Guid.Empty)
                _id = Guid.NewGuid();

            if (intermediateAtuacaoModel != null)
                return new Atuacao
                {
                    Local = intermediateAtuacaoModel.Local,
                    DataCadastro = intermediateAtuacaoModel.DataCadastro,
                    DataModificacao = intermediateAtuacaoModel.DataModificacao,
                    Empresa = intermediateAtuacaoModel.Empresa,
                    Id = _id,
                    IsAtivo = intermediateAtuacaoModel.IsAtivo,
                    Descricao = intermediateAtuacaoModel.Descricao
                };

            return new();
        }

        /// <summary>
        /// Obtem um objeto Compromisso à partir de um objeto do tipo IntermediateCompromissoModel.
        /// </summary>
        /// <param name="intermediateCompromissoModel">The IntermediateCompromissoModel parameter.</param>
        /// <returns>Compromisso.</returns>
        public static Compromisso GetCompromissoFromIntermediateCompromissoModel(IntermediateCompromissoModel? intermediateCompromissoModel)
        {
            Guid _id = Guid.Empty;

            if (intermediateCompromissoModel != null && intermediateCompromissoModel.Id != Guid.Empty.ToString())
                Guid.TryParse(intermediateCompromissoModel.Id, out _id);

            if (_id == Guid.Empty)
                _id = Guid.NewGuid();

            if (intermediateCompromissoModel != null)
                return new Compromisso
                {
                    Local = intermediateCompromissoModel.Local,
                    DataCadastro = intermediateCompromissoModel.DataCadastro,
                    DataModificacao = intermediateCompromissoModel.DataModificacao,
                    HoraInicio = intermediateCompromissoModel.HoraInicio,
                    Id = _id,
                    IsAtivo = intermediateCompromissoModel.IsAtivo,
                    Descricao = intermediateCompromissoModel.Descricao
                };

            return new();
        }












        /// <summary>
        /// Obtem um objeto Curso à partir de um objeto do tipo IntermediateCursoModel.
        /// </summary>
        /// <param name="intermediateCursoModel">The IntermediateCursoModel parameter.</param>
        /// <returns>Curso.</returns>
        public static Curso GetCursoFromIntermediateCursoModel(IntermediateCursoModel? intermediateCursoModel)
        {
            Guid _id = Guid.Empty;

            if (intermediateCursoModel != null && intermediateCursoModel.Id != Guid.Empty.ToString())
                Guid.TryParse(intermediateCursoModel.Id, out _id);

            if (_id == Guid.Empty)
                _id = Guid.NewGuid();

            if (intermediateCursoModel != null)
                return new Curso
                {
                    Local = intermediateCursoModel.Local,
                    DataCadastro = intermediateCursoModel.DataCadastro,
                    DataModificacao = intermediateCursoModel.DataModificacao,
                    Instituicao = intermediateCursoModel.Instituicao,
                    Id = _id,
                    IsAtivo = intermediateCursoModel.IsAtivo,
                    Descricao = intermediateCursoModel.Descricao
                };

            return new();
        }

        /// <summary>
        /// The EntityEnum enum.
        /// </summary>
        public enum EntityEnum
        {
            Usuario = 0,
            Atividade = 1,
            Despesa = 2,
            Atuacao = 3,
            Compromisso = 4,
            Curso = 5
        }

        /// <summary>
        /// The ObjectEnum enum.
        /// </summary>
        public enum ObjectEnum
        {
            ListaStrings = 0
        }
    }
}

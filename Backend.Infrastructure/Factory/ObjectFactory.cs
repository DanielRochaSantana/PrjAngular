using Backend.Domain.Models;
using Backend.Domain.Models.Entity;

namespace Backend.Infrastructure.Factory
{
    public static class ObjectFactory
    {
        public static object GetObject(EntityEnum entityEnum, Guid Id)
        {
            switch (entityEnum)
            {
                case EntityEnum.Usuario:
                    return new Usuario { Id = Id };
                case EntityEnum.Atividade:
                    return new Atividade { Id = Id };
                default:
                    return new();
            }
        }

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

        public enum EntityEnum
        {
            Usuario = 0,
            Atividade = 1
        }

        public enum ObjectEnum
        {
            ListaStrings = 0
        }
    }
}

using Backend.Application.Interfaces;
using Backend.Domain.Models;
using Backend.Domain.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Constants = Backend.Infrastructure.Utils.Constants;
using ObjectFactory = Backend.Infrastructure.Factory.ObjectFactory;

namespace Backend.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsuarioController : ControllerBase
    {
        protected readonly IUsuarioService _usuarioService;

        /// <summary>
        /// Construtor.
        /// </summary>
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Efetua a adição de um usuário.
        /// </summary>
        /// <param name="itermediateUsuarioModel">O parâmetro usuarioModel.</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpPost(Name = "AdicionarUsuario")]
        public ActionResult<HttpResponseMessage> AdicionarUsuario([FromBody] IntermediateUsuarioModel itermediateUsuarioModel)
        {
            try
            {
                if (itermediateUsuarioModel == null || itermediateUsuarioModel.IsEdit)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                Usuario usuario = ObjectFactory.GetUsuarioFromIntermediateUsuarioModel(itermediateUsuarioModel);

                _usuarioService.Adicionar(usuario, Constants.ID, Constants.USUARIO);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a remoção de um usuário.
        /// </summary>
        /// <param name="Id">O parâmetro Id.</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpDelete(Name = "ApagarUsuario")]
        public ActionResult<HttpResponseMessage> ApagarUsuario(Guid Id)
        {
            try
            {
                if (Id == Guid.Empty)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _usuarioService.Remover(Id, ObjectFactory.EntityEnum.Usuario, Constants.USUARIO, Constants.ID);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a atualização de um usuário.
        /// </summary>
        /// <param name="Id">O parâmetro IdUsuario</param>
        /// <param name="_usuario">O parâmetro _usuario</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpPut(Name = "AtualizarUsuario")]
        public ActionResult<HttpResponseMessage> AtualizarUsuario([FromQuery] string Id, [FromBody] IntermediateUsuarioModel? _usuario)
        {
            try
            {
                if (_usuario == null ||
                    !_usuario.IsEdit ||
                    string.IsNullOrEmpty(Id) ||
                    string.IsNullOrWhiteSpace(Id) ||
                    Id == Guid.Empty.ToString()
                    )
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _usuario.Id = Id;

                Usuario usuario = ObjectFactory.GetUsuarioFromIntermediateUsuarioModel(_usuario);

                _usuarioService.Atualizar(usuario, Constants.ID, Constants.USUARIO);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Obtem os usuários.
        /// </summary>
        /// <returns>ActionResult IList Usuario.</returns>
        [HttpGet(Name = "ObterUsuarios")]
        public ActionResult<IList<Usuario>> ObterUsuarios()
        {
            try
            {
                IList<Usuario> usuarios = _usuarioService.ListarRegistros(Constants.USUARIO).OrderByDescending(i => i.Nome).ToList();
                return Ok(usuarios);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Obtem Usuário por Id.
        /// </summary>
        /// <param name="Id">O parâmetro Id.</param>
        /// <returns>ActionResult Usuario.</returns>
        [HttpGet(Name = "ObterUsuarioPorId")]
        public ActionResult<Usuario> ObterUsuarioPorId(Guid Id)
        {
            try
            {
                Usuario? usuario = _usuarioService.EncontrarPorCodigo(Id,
                                                                      ObjectFactory.EntityEnum.Usuario,
                                                                      Constants.USUARIO,
                                                                      Constants.ID);
                return Ok(usuario);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

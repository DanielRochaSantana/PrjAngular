using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public UsuarioController() { }

        /// <summary>
        /// Obtem a lista de usuários.
        /// </summary>
        /// <returns>List object.</returns>
        [HttpGet(Name = "ListarUsuarios")]
        public List<object> ListarUsuarios()
        {
            return new List<object> { new object(), new object() };
        }

        /// <summary>
        /// Obtem um usuário.
        /// </summary>
        /// <returns>object.</returns>
        [HttpGet(Name = "ObterUsuario")]
        public object ObterUsuario([FromQuery] int Id)
        {
            return new object();
        }

        /// <summary>
        /// Efetua a atualização de um usuário.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>HttpResponseMessage.</returns>
        [HttpPut(Name = "AtualizarUsuario")]
        public HttpResponseMessage AtualizarUsuario([FromQuery] int Id, [FromBody] object usuario)
        {
            if (usuario == null || Id <= 0)
                return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        
        /// <summary>
        /// Efetua a atualização de um usuário.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>HttpResponseMessage.</returns>
        [HttpDelete(Name = "RemoverUsuario")]
        public HttpResponseMessage RemoverUsuario([FromQuery] int Id)
        {
            if (Id <= 0)
                return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
        
        /// <summary>
        /// Efetua a adição de um usuário.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>HttpResponseMessage.</returns>
        [HttpPost(Name = "AdicionarUsuario")]
        public HttpResponseMessage AdicionarUsuario([FromBody] object usuario)
        {
            if (usuario == null)
                return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}

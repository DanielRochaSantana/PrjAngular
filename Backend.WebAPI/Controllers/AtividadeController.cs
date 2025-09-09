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
    public class AtividadeController : ControllerBase
    {
        protected readonly IAtividadeService _atividadeService;

        /// <summary>
        /// Construtor.
        /// </summary>
        public AtividadeController(IAtividadeService atividadeService)
        {
            _atividadeService = atividadeService;
        }

        /// <summary>
        /// Efetua a adi��o de um usu�rio.
        /// </summary>
        /// <param name="itermediateAtividadeModel">O par�metro atividadeModel.</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpPost(Name = "AdicionarAtividade")]
        public ActionResult<HttpResponseMessage> AdicionarAtividade([FromBody] IntermediateAtividadeModel itermediateAtividadeModel)
        {
            try
            {
                if (itermediateAtividadeModel == null || itermediateAtividadeModel.IsEdit)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                Atividade atividade = ObjectFactory.GetAtividadeFromIntermediateAtividadeModel(itermediateAtividadeModel);

                _atividadeService.Adicionar(atividade, Constants.ID, Constants.ATIVIDADE);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a remo��o de um usu�rio.
        /// </summary>
        /// <param name="Id">O par�metro Id.</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpDelete(Name = "ApagarAtividade")]
        public ActionResult<HttpResponseMessage> ApagarAtividade(Guid Id)
        {
            try
            {
                if (Id == Guid.Empty)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _atividadeService.Remover(Id, ObjectFactory.EntityEnum.Atividade, Constants.ATIVIDADE, Constants.ID);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a atualiza��o de um usu�rio.
        /// </summary>
        /// <param name="Id">O par�metro IdAtividade</param>
        /// <param name="_atividade">O par�metro _atividade</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpPut(Name = "AtualizarAtividade")]
        public ActionResult<HttpResponseMessage> AtualizarAtividade([FromQuery] string Id, [FromBody] IntermediateAtividadeModel? _atividade)
        {
            try
            {
                if (_atividade == null ||
                    !_atividade.IsEdit ||
                    string.IsNullOrEmpty(Id) ||
                    string.IsNullOrWhiteSpace(Id) ||
                    Id == Guid.Empty.ToString()
                    )
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _atividade.Id = Id;

                Atividade atividade = ObjectFactory.GetAtividadeFromIntermediateAtividadeModel(_atividade);

                _atividadeService.Atualizar(atividade, Constants.ID, Constants.ATIVIDADE);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Obtem os usu�rios.
        /// </summary>
        /// <returns>ActionResult IList Atividade.</returns>
        [HttpGet(Name = "ObterAtividades")]
        public ActionResult<IList<Atividade>> ObterAtividades()
        {
            try
            {
                IList<Atividade> atividades = _atividadeService.ListarRegistros(Constants.ATIVIDADE).OrderByDescending(i => i.Descricao).ToList();
                return Ok(atividades);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Obtem Usu�rio por Id.
        /// </summary>
        /// <param name="Id">O par�metro Id.</param>
        /// <returns>ActionResult Atividade.</returns>
        [HttpGet(Name = "ObterAtividadePorId")]
        public ActionResult<Atividade> ObterAtividadePorId(Guid Id)
        {
            try
            {
                Atividade? atividade = _atividadeService.EncontrarPorCodigo(Id,
                                                                      ObjectFactory.EntityEnum.Atividade,
                                                                      Constants.ATIVIDADE,
                                                                      Constants.ID);
                return Ok(atividade);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

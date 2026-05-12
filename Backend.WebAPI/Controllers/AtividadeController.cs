#region Usings
using Backend.Application.Interfaces;
using Backend.Domain.Models;
using Backend.Domain.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Constants = Backend.Infrastructure.Utils.Constants;
using ObjectFactory = Backend.Infrastructure.Factory.ObjectFactory; 
#endregion Usings

namespace Backend.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AtividadeController : ControllerBase
    {
        #region Controller Fields
        /// <summary>
        /// The _atividadeService field.
        /// </summary>
        protected readonly IAtividadeService _atividadeService;
        #endregion Controller Fields

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public AtividadeController(IAtividadeService atividadeService)
        {
            _atividadeService = atividadeService;
        }
        #endregion Constructor

        #region Controller EndPoints
        /// <summary>
        /// Efetua a adição de um atividade.
        /// </summary>
        /// <param name="intermediateAtividadeModel">The intermediateAtividadeModel parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpPost(Name = "AdicionarAtividade")]
        public ActionResult<HttpResponseMessage> AdicionarAtividade([FromBody] IntermediateAtividadeModel intermediateAtividadeModel)
        {
            try
            {
                if (intermediateAtividadeModel == null || intermediateAtividadeModel.IsEdit)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                Atividade atividade = ObjectFactory.GetAtividadeFromIntermediateAtividadeModel(intermediateAtividadeModel);

                _atividadeService.Adicionar(atividade, Constants.ID, Constants.ATIVIDADE);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a remoção de um atividade.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpDelete(Name = "ApagarAtividade")]
        public ActionResult<HttpResponseMessage> ApagarAtividade(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _atividadeService.Remover(id, ObjectFactory.EntityEnum.Atividade, Constants.ATIVIDADE, Constants.ID);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a atualização de um atividade.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="atividade">The atividade parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpPut(Name = "AtualizarAtividade")]
        public ActionResult<HttpResponseMessage> AtualizarAtividade([FromQuery] string id, [FromBody] IntermediateAtividadeModel? atividade)
        {
            try
            {
                if (atividade == null ||
                    !atividade.IsEdit ||
                    string.IsNullOrEmpty(id) ||
                    string.IsNullOrWhiteSpace(id) ||
                    id == Guid.Empty.ToString()
                    )
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                atividade.Id = id;

                Atividade _atividade = ObjectFactory.GetAtividadeFromIntermediateAtividadeModel(atividade);

                _atividadeService.Atualizar(_atividade, Constants.ID, Constants.ATIVIDADE);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Obtem os atividades.
        /// </summary>
        /// <returns>ActionResult of IList of Atividade.</returns>
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
        /// Obtem Atividade por Id.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <returns>ActionResult of Atividade.</returns>
        [HttpGet(Name = "ObterAtividadePorId")]
        public ActionResult<Atividade> ObterAtividadePorId(Guid id)
        {
            try
            {
                Atividade? atividade = _atividadeService.EncontrarPorCodigo(id,
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
        #endregion Controller EndPoints
    }
}

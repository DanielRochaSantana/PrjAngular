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
    public class CompromissoController : ControllerBase
    {
        protected readonly ICompromissoService _compromissoService;

        /// <summary>
        /// Construtor.
        /// </summary>
        public CompromissoController(ICompromissoService compromissoService)
        {
            _compromissoService = compromissoService;
        }

        /// <summary>
        /// Efetua a adição de um compromisso.
        /// </summary>
        /// <param name="itermediateCompromissoModel">O parâmetro compromissoModel.</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpPost(Name = "AdicionarCompromisso")]
        public ActionResult<HttpResponseMessage> AdicionarCompromisso([FromBody] IntermediateCompromissoModel itermediateCompromissoModel)
        {
            try
            {
                if (itermediateCompromissoModel == null || itermediateCompromissoModel.IsEdit)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                Compromisso compromisso = ObjectFactory.GetCompromissoFromIntermediateCompromissoModel(itermediateCompromissoModel);

                _compromissoService.Adicionar(compromisso, Constants.ID, Constants.COMPROMISSO);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a remoção de um compromisso.
        /// </summary>
        /// <param name="Id">O parâmetro Id.</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpDelete(Name = "ApagarCompromisso")]
        public ActionResult<HttpResponseMessage> ApagarCompromisso(Guid Id)
        {
            try
            {
                if (Id == Guid.Empty)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _compromissoService.Remover(Id, ObjectFactory.EntityEnum.Compromisso, Constants.COMPROMISSO, Constants.ID);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a atualização de um compromisso.
        /// </summary>
        /// <param name="Id">O parâmetro IdCompromisso</param>
        /// <param name="_compromisso">O parâmetro _compromisso</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpPut(Name = "AtualizarCompromisso")]
        public ActionResult<HttpResponseMessage> AtualizarCompromisso([FromQuery] string Id, [FromBody] IntermediateCompromissoModel? _compromisso)
        {
            try
            {
                if (_compromisso == null ||
                    !_compromisso.IsEdit ||
                    string.IsNullOrEmpty(Id) ||
                    string.IsNullOrWhiteSpace(Id) ||
                    Id == Guid.Empty.ToString()
                    )
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _compromisso.Id = Id;

                Compromisso compromisso = ObjectFactory.GetCompromissoFromIntermediateCompromissoModel(_compromisso);

                _compromissoService.Atualizar(compromisso, Constants.ID, Constants.COMPROMISSO);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Obtem as compromissos.
        /// </summary>
        /// <returns>ActionResult IList Compromisso.</returns>
        [HttpGet(Name = "ObterCompromissos")]
        public ActionResult<IList<Compromisso>> ObterCompromissos()
        {
            try
            {
                IList<Compromisso> compromissos = _compromissoService.ListarRegistros(Constants.COMPROMISSO).OrderByDescending(i => i.Descricao).ToList();
                return Ok(compromissos);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Obtem Compromisso por Id.
        /// </summary>
        /// <param name="Id">O parâmetro Id.</param>
        /// <returns>ActionResult Compromisso.</returns>
        [HttpGet(Name = "ObterCompromissoPorId")]
        public ActionResult<Compromisso> ObterCompromissoPorId(Guid Id)
        {
            try
            {
                Compromisso? compromisso = _compromissoService.EncontrarPorCodigo(Id,
                                                                      ObjectFactory.EntityEnum.Compromisso,
                                                                      Constants.COMPROMISSO,
                                                                      Constants.ID);
                return Ok(compromisso);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

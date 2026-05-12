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
    public class CompromissoController : ControllerBase
    {
        #region Controller Fields
        /// <summary>
        /// The _compromissoService field.
        /// </summary>
        protected readonly ICompromissoService _compromissoService;
        #endregion Controller Fields

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public CompromissoController(ICompromissoService compromissoService)
        {
            _compromissoService = compromissoService;
        }
        #endregion Constructor

        #region Controller EndPoints
        /// <summary>
        /// Efetua a adição de um compromisso.
        /// </summary>
        /// <param name="intermediateCompromissoModel">The intermediateCompromissoModel parameter.</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpPost(Name = "AdicionarCompromisso")]
        public ActionResult<HttpResponseMessage> AdicionarCompromisso([FromBody] IntermediateCompromissoModel intermediateCompromissoModel)
        {
            try
            {
                if (intermediateCompromissoModel == null || intermediateCompromissoModel.IsEdit)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                Compromisso compromisso = ObjectFactory.GetCompromissoFromIntermediateCompromissoModel(intermediateCompromissoModel);

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
        /// <param name="id">The id parameter.</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpDelete(Name = "ApagarCompromisso")]
        public ActionResult<HttpResponseMessage> ApagarCompromisso(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _compromissoService.Remover(id, ObjectFactory.EntityEnum.Compromisso, Constants.COMPROMISSO, Constants.ID);

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
        /// <param name="id">The id parameter.</param>
        /// <param name="compromisso">The compromisso parameter.</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpPut(Name = "AtualizarCompromisso")]
        public ActionResult<HttpResponseMessage> AtualizarCompromisso([FromQuery] string id, [FromBody] IntermediateCompromissoModel? compromisso)
        {
            try
            {
                if (compromisso == null ||
                    !compromisso.IsEdit ||
                    string.IsNullOrEmpty(id) ||
                    string.IsNullOrWhiteSpace(id) ||
                    id == Guid.Empty.ToString()
                    )
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                compromisso.Id = id;

                Compromisso _compromisso = ObjectFactory.GetCompromissoFromIntermediateCompromissoModel(compromisso);

                _compromissoService.Atualizar(_compromisso, Constants.ID, Constants.COMPROMISSO);

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
        /// <param name="id">The id parameter.</param>
        /// <returns>ActionResult Compromisso.</returns>
        [HttpGet(Name = "ObterCompromissoPorId")]
        public ActionResult<Compromisso> ObterCompromissoPorId(Guid id)
        {
            try
            {
                Compromisso? compromisso = _compromissoService.EncontrarPorCodigo(id,
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
        #endregion Controller EndPoints
    }
}

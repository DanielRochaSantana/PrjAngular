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
    public class DespesaController : ControllerBase
    {
        #region Controller Fields
        /// <summary>
        /// The _despesaService field.
        /// </summary>
        protected readonly IDespesaService _despesaService;
        #endregion Controller Fields

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public DespesaController(IDespesaService despesaService)
        {
            _despesaService = despesaService;
        }
        #endregion Constructor

        #region Controller EndPoints
        /// <summary>
        /// Efetua a adição de um despesa.
        /// </summary>
        /// <param name="intermediateDespesaModel">The intermediateDespesaModel parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpPost(Name = "AdicionarDespesa")]
        public ActionResult<HttpResponseMessage> AdicionarDespesa([FromBody] IntermediateDespesaModel intermediateDespesaModel)
        {
            try
            {
                if (intermediateDespesaModel == null || intermediateDespesaModel.IsEdit)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                Despesa despesa = ObjectFactory.GetDespesaFromIntermediateDespesaModel(intermediateDespesaModel);

                _despesaService.Adicionar(despesa, Constants.ID, Constants.DESPESA);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a remoção de um despesa.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpDelete(Name = "ApagarDespesa")]
        public ActionResult<HttpResponseMessage> ApagarDespesa(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _despesaService.Remover(id, ObjectFactory.EntityEnum.Despesa, Constants.DESPESA, Constants.ID);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a atualização de um despesa.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="despesa">The despesa parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpPut(Name = "AtualizarDespesa")]
        public ActionResult<HttpResponseMessage> AtualizarDespesa([FromQuery] string id, [FromBody] IntermediateDespesaModel? despesa)
        {
            try
            {
                if (despesa == null ||
                    !despesa.IsEdit ||
                    string.IsNullOrEmpty(id) ||
                    string.IsNullOrWhiteSpace(id) ||
                    id == Guid.Empty.ToString()
                    )
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                despesa.Id = id;

                Despesa _despesa = ObjectFactory.GetDespesaFromIntermediateDespesaModel(despesa);

                _despesaService.Atualizar(_despesa, Constants.ID, Constants.DESPESA);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Obtem os despesas.
        /// </summary>
        /// <returns>ActionResult of IList of Despesa.</returns>
        [HttpGet(Name = "ObterDespesas")]
        public ActionResult<IList<Despesa>> ObterDespesas()
        {
            try
            {
                IList<Despesa> despesas = _despesaService.ListarRegistros(Constants.DESPESA).OrderByDescending(i => i.Descricao).ToList();
                return Ok(despesas);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Obtem Despesa por Id.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <returns>ActionResult of Despesa.</returns>
        [HttpGet(Name = "ObterDespesaPorId")]
        public ActionResult<Despesa> ObterDespesaPorId(Guid id)
        {
            try
            {
                Despesa? despesa = _despesaService.EncontrarPorCodigo(id,
                                                                      ObjectFactory.EntityEnum.Despesa,
                                                                      Constants.DESPESA,
                                                                      Constants.ID);
                return Ok(despesa);
            }
            catch
            {
                return BadRequest();
            }
        } 
        #endregion
    }
}

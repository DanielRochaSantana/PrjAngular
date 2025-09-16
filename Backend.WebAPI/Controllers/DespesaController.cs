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
    public class DespesaController : ControllerBase
    {
        protected readonly IDespesaService _despesaService;

        /// <summary>
        /// Construtor.
        /// </summary>
        public DespesaController(IDespesaService despesaService)
        {
            _despesaService = despesaService;
        }

        /// <summary>
        /// Efetua a adição de um usuário.
        /// </summary>
        /// <param name="itermediateDespesaModel">O parâmetro despesaModel.</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpPost(Name = "AdicionarDespesa")]
        public ActionResult<HttpResponseMessage> AdicionarDespesa([FromBody] IntermediateDespesaModel itermediateDespesaModel)
        {
            try
            {
                if (itermediateDespesaModel == null || itermediateDespesaModel.IsEdit)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                Despesa despesa = ObjectFactory.GetDespesaFromIntermediateDespesaModel(itermediateDespesaModel);

                _despesaService.Adicionar(despesa, Constants.ID, Constants.DESPESA);

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
        [HttpDelete(Name = "ApagarDespesa")]
        public ActionResult<HttpResponseMessage> ApagarDespesa(Guid Id)
        {
            try
            {
                if (Id == Guid.Empty)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _despesaService.Remover(Id, ObjectFactory.EntityEnum.Despesa, Constants.DESPESA, Constants.ID);

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
        /// <param name="Id">O parâmetro IdDespesa</param>
        /// <param name="_despesa">O parâmetro _despesa</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpPut(Name = "AtualizarDespesa")]
        public ActionResult<HttpResponseMessage> AtualizarDespesa([FromQuery] string Id, [FromBody] IntermediateDespesaModel? _despesa)
        {
            try
            {
                if (_despesa == null ||
                    !_despesa.IsEdit ||
                    string.IsNullOrEmpty(Id) ||
                    string.IsNullOrWhiteSpace(Id) ||
                    Id == Guid.Empty.ToString()
                    )
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _despesa.Id = Id;

                Despesa despesa = ObjectFactory.GetDespesaFromIntermediateDespesaModel(_despesa);

                _despesaService.Atualizar(despesa, Constants.ID, Constants.DESPESA);

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
        /// <returns>ActionResult IList Despesa.</returns>
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
        /// Obtem Usuário por Id.
        /// </summary>
        /// <param name="Id">O parâmetro Id.</param>
        /// <returns>ActionResult Despesa.</returns>
        [HttpGet(Name = "ObterDespesaPorId")]
        public ActionResult<Despesa> ObterDespesaPorId(Guid Id)
        {
            try
            {
                Despesa? despesa = _despesaService.EncontrarPorCodigo(Id,
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
    }
}

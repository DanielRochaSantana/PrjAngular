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
    public class AtuacaoController : ControllerBase
    {
        #region Controller Fields
        /// <summary>
        /// The _atuacaoService field.
        /// </summary>
        protected readonly IAtuacaoService _atuacaoService;
        #endregion Controller Fields

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public AtuacaoController(IAtuacaoService atuacaoService)
        {
            _atuacaoService = atuacaoService;
        }
        #endregion Constructor

        #region Controller EndPoints
        /// <summary>
        /// Efetua a adição de um atuação.
        /// </summary>
        /// <param name="intermediateAtuacaoModel">The intermediateAtuacaoModel parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpPost(Name = "AdicionarAtuacao")]
        public ActionResult<HttpResponseMessage> AdicionarAtuacao([FromBody] IntermediateAtuacaoModel intermediateAtuacaoModel)
        {
            try
            {
                if (intermediateAtuacaoModel == null || intermediateAtuacaoModel.IsEdit)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                Atuacao atuacao = ObjectFactory.GetAtuacaoFromIntermediateAtuacaoModel(intermediateAtuacaoModel);

                _atuacaoService.Adicionar(atuacao, Constants.ID, Constants.ATUACAO);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a remoção de um atuação.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpDelete(Name = "ApagarAtuacao")]
        public ActionResult<HttpResponseMessage> ApagarAtuacao(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _atuacaoService.Remover(id, ObjectFactory.EntityEnum.Atuacao, Constants.ATUACAO, Constants.ID);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a atualização de um atuação.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="atuacao">The atuacao parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpPut(Name = "AtualizarAtuacao")]
        public ActionResult<HttpResponseMessage> AtualizarAtuacao([FromQuery] string id, [FromBody] IntermediateAtuacaoModel? atuacao)
        {
            try
            {
                if (atuacao == null ||
                    !atuacao.IsEdit ||
                    string.IsNullOrEmpty(id) ||
                    string.IsNullOrWhiteSpace(id) ||
                    id == Guid.Empty.ToString()
                    )
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                atuacao.Id = id;

                Atuacao _atuacao = ObjectFactory.GetAtuacaoFromIntermediateAtuacaoModel(atuacao);

                _atuacaoService.Atualizar(_atuacao, Constants.ID, Constants.ATUACAO);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Obtem as atuações.
        /// </summary>
        /// <returns>ActionResult of IList of Atuacao.</returns>
        [HttpGet(Name = "ObterAtuacoes")]
        public ActionResult<IList<Atuacao>> ObterAtuacoes()
        {
            try
            {
                IList<Atuacao> atuacoes = _atuacaoService.ListarRegistros(Constants.ATUACAO).OrderByDescending(i => i.Descricao).ToList();
                return Ok(atuacoes);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Obtem Atuação por Id.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <returns>ActionResult of Atuacao.</returns>
        [HttpGet(Name = "ObterAtuacaoPorId")]
        public ActionResult<Atuacao> ObterAtuacaoPorId(Guid id)
        {
            try
            {
                Atuacao? atuacao = _atuacaoService.EncontrarPorCodigo(id,
                                                                      ObjectFactory.EntityEnum.Atuacao,
                                                                      Constants.ATUACAO,
                                                                      Constants.ID);
                return Ok(atuacao);
            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion Controller EndPoints
    }
}

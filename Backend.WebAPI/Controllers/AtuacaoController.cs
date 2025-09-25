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
    public class AtuacaoController : ControllerBase
    {
        protected readonly IAtuacaoService _atuacaoService;

        /// <summary>
        /// Construtor.
        /// </summary>
        public AtuacaoController(IAtuacaoService atuacaoService)
        {
            _atuacaoService = atuacaoService;
        }

        /// <summary>
        /// Efetua a adição de um atuação.
        /// </summary>
        /// <param name="itermediateAtuacaoModel">O parâmetro atuacaoModel.</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpPost(Name = "AdicionarAtuacao")]
        public ActionResult<HttpResponseMessage> AdicionarAtuacao([FromBody] IntermediateAtuacaoModel itermediateAtuacaoModel)
        {
            try
            {
                if (itermediateAtuacaoModel == null || itermediateAtuacaoModel.IsEdit)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                Atuacao atuacao = ObjectFactory.GetAtuacaoFromIntermediateAtuacaoModel(itermediateAtuacaoModel);

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
        /// <param name="Id">O parâmetro Id.</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpDelete(Name = "ApagarAtuacao")]
        public ActionResult<HttpResponseMessage> ApagarAtuacao(Guid Id)
        {
            try
            {
                if (Id == Guid.Empty)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _atuacaoService.Remover(Id, ObjectFactory.EntityEnum.Atuacao, Constants.ATUACAO, Constants.ID);

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
        /// <param name="Id">O parâmetro IdAtuacao</param>
        /// <param name="_atuacao">O parâmetro _atuacao</param>
        /// <returns>ActionResult HttpResponseMessage.</returns>
        [HttpPut(Name = "AtualizarAtuacao")]
        public ActionResult<HttpResponseMessage> AtualizarAtuacao([FromQuery] string Id, [FromBody] IntermediateAtuacaoModel? _atuacao)
        {
            try
            {
                if (_atuacao == null ||
                    !_atuacao.IsEdit ||
                    string.IsNullOrEmpty(Id) ||
                    string.IsNullOrWhiteSpace(Id) ||
                    Id == Guid.Empty.ToString()
                    )
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _atuacao.Id = Id;

                Atuacao atuacao = ObjectFactory.GetAtuacaoFromIntermediateAtuacaoModel(_atuacao);

                _atuacaoService.Atualizar(atuacao, Constants.ID, Constants.ATUACAO);

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
        /// <returns>ActionResult IList Atuacao.</returns>
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
        /// <param name="Id">O parâmetro Id.</param>
        /// <returns>ActionResult Atuacao.</returns>
        [HttpGet(Name = "ObterAtuacaoPorId")]
        public ActionResult<Atuacao> ObterAtuacaoPorId(Guid Id)
        {
            try
            {
                Atuacao? atuacao = _atuacaoService.EncontrarPorCodigo(Id,
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
    }
}

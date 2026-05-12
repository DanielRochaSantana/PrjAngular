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
    public class CursoController : ControllerBase
    {
        #region Controller Fields
        /// <summary>
        /// The _cursoService field.
        /// </summary>
        protected readonly ICursoService _cursoService;
        #endregion Controller Fields
                   
        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }
        #endregion Constructor

        #region Controller EndPoints
        /// <summary>
        /// Efetua a adição de um curso.
        /// </summary>
        /// <param name="intermediateCursoModel">The intermediateCursoModel parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpPost(Name = "AdicionarCurso")]
        public ActionResult<HttpResponseMessage> AdicionarCurso([FromBody] IntermediateCursoModel intermediateCursoModel)
        {
            try
            {
                if (intermediateCursoModel == null || intermediateCursoModel.IsEdit)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                Curso curso = ObjectFactory.GetCursoFromIntermediateCursoModel(intermediateCursoModel);

                _cursoService.Adicionar(curso, Constants.ID, Constants.CURSO);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a remoção de um curso.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpDelete(Name = "ApagarCurso")]
        public ActionResult<HttpResponseMessage> ApagarCurso(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                _cursoService.Remover(id, ObjectFactory.EntityEnum.Curso, Constants.CURSO, Constants.ID);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Efetua a atualização de um curso.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <param name="curso">The curso parameter.</param>
        /// <returns>ActionResult of HttpResponseMessage.</returns>
        [HttpPut(Name = "AtualizarCurso")]
        public ActionResult<HttpResponseMessage> AtualizarCurso([FromQuery] string id, [FromBody] IntermediateCursoModel? curso)
        {
            try
            {
                if (curso == null ||
                    !curso.IsEdit ||
                    string.IsNullOrEmpty(id) ||
                    string.IsNullOrWhiteSpace(id) ||
                    id == Guid.Empty.ToString()
                    )
                    return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));

                curso.Id = id;

                Curso _curso = ObjectFactory.GetCursoFromIntermediateCursoModel(curso);

                _cursoService.Atualizar(_curso, Constants.ID, Constants.CURSO);

                return Ok(new HttpResponseMessage(HttpStatusCode.OK));
            }
            catch
            {
                return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        /// Obtem as cursos.
        /// </summary>
        /// <returns>ActionResult of IList of Curso.</returns>
        [HttpGet(Name = "ObterCursos")]
        public ActionResult<IList<Curso>> ObterCursos()
        {
            try
            {
                IList<Curso> cursos = _cursoService.ListarRegistros(Constants.CURSO).OrderByDescending(i => i.Descricao).ToList();
                return Ok(cursos);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Obtem Curso por Id.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <returns>ActionResult of Curso.</returns>
        [HttpGet(Name = "ObterCursoPorId")]
        public ActionResult<Curso> ObterCursoPorId(Guid id)
        {
            try
            {
                Curso? curso = _cursoService.EncontrarPorCodigo(id,
                                                                      ObjectFactory.EntityEnum.Curso,
                                                                      Constants.CURSO,
                                                                      Constants.ID);
                return Ok(curso);
            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion Controller EndPoints
    }
}

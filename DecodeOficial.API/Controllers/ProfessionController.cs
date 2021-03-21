using DecodeOficial.Application.Command;
using DecodeOficial.Application.DTO.Profession;
using DecodeOficial.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Linq;
using System.Threading.Tasks;

namespace DecodeOficial.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionController : Controller
    {
        private readonly IMediator _mediator;

        public ProfessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Get
        #region Documentation
        /// <summary>
        /// Returns all the registered professions
        /// </summary>
        /// <returns>A list with all registered professions</returns>
        /// <remarks> The API returns a list with all registered professions</remarks>
        /// <response code="200">A list - full or empty - of professions </response>
        #endregion
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new ProfessionGetAllQuery();
            var result = await _mediator.Send(query);
            Log.Information("ProfessionController: Returned list of professions with {0} registers", result.Count().ToString());
            return Ok(result);
        }
        #endregion 

        #region Get {id}
        #region Documentation
        /// <summary>
        /// Search for a specific profession based on the Id
        /// </summary>
        /// <param name="id">The Id of the profession</param>
        /// <returns>The register corresponding to the informed Id</returns>
        /// <response code="200">Returns the register corresponding to the informed Id</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new ProfessionGetByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result != null)
            {
                Log.Information("ProfessionController: Returned profession {@result}", result);
                return Ok(result);
            }
            else
            {
                Log.Error("ProfessionController: Returned null on searching by Id: {0}", id.ToString());
                return NotFound();
            }
        }
        #endregion

        #region Search
        #region Documentation
        /// <summary>
        /// Searchs for the role of the registered profession
        /// </summary>
        /// <param name="search">The role of the profession</param>
        /// <returns>A list of professions whose role match the searched expression</returns>
        /// <response code="200">Returns a list -full or empty- of professions that match the searched expression</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("search/{search}")]
        public async Task<IActionResult> Search(string search)
        {
            var query = new ProfessionSearchQuery { search = search };
            var result = await _mediator.Send(query);
            if (result.Count() != 0)
            {
                Log.Information("ProfessionController: Returned list of professions for searching with {0} registers with filter {1}", result.Count().ToString(), search);
            }
            else
            {
                Log.Error("ProfessionController: Returned null on searching roles by filter: {0}", search);
            }
            return Ok(result);
        }
        #endregion

        #region Create
        #region Documentation
        /// <summary>
        /// Create a profession
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST
        ///     {
        ///        "role": "Developer"
        ///     }    
        /// </remarks>
        /// <param name="professionCreateDTO"></param>
        /// <returns>Confirmation message</returns>
        /// <response code="200">Returns a confirmation message</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProfessionCreateDTO professionCreateDTO)
        {
            var command = new ProfessionCreateCommand { professionCreateDTO = professionCreateDTO };
            await _mediator.Send(command);
            Log.Information("ProfessionController: Created profession {@profession}", professionCreateDTO);
            return Ok("Profession registered!");
        }
        #endregion

        #region Update
        #region Documentation
        /// <summary>
        /// Update a profession
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "id": 1,
        ///        "role": "Developer"
        ///     }
        /// </remarks>
        /// <param name="professionUpdateDTO"></param>
        /// <returns>Confirmation message</returns>
        /// <response code="200">Returns a confirmation message</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProfessionUpdateDTO professionUpdateDTO)
        {
            var query = new ProfessionGetByIdQuery { Id = professionUpdateDTO.Id };
            var result = await _mediator.Send(query);

            if (result != null)
            {
                var command = new ProfessionUpdateCommand { professionUpdateDTO = professionUpdateDTO };
                await _mediator.Send(command);
                var postUpdate = new PersonGetByIdQuery { Id = professionUpdateDTO.Id };
                Log.Information("ProfessionController: Update profession Id: {id}. From {@result} to {@postUpdate}", professionUpdateDTO.Id.ToString(), result, postUpdate);
                return Ok("Profession updated!");
            }
            else
            {
                Log.Error("ProfessionController: Returned null on searching for update with Id: {0}", professionUpdateDTO.Id.ToString());
                return NotFound();
            }
        }
        #endregion

        #region Delete
        #region Documentation
        /// <summary>
        /// Deletes a profession
        /// </summary>
        /// <param name="id">The Id of the profession</param>
        /// <returns>Confirmation message</returns>
        /// <response code="200">Returns a confirmation message</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var query = new ProfessionGetByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result != null)
            {
                var command = new ProfessionDeleteCommand { Id = id };
                await _mediator.Send(command);
                Log.Information("ProfessionController: Deleted profession {@result}", result);
                return Ok("Profession deleted!");
            }
            else
            {
                Log.Error("ProfessionController: Returned null on searching for delete by Id: {0}", id.ToString());
                return NotFound();
            }
        }
        #endregion
    }
}

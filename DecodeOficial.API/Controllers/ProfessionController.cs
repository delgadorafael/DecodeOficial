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
        private const string thisController = nameof(ProfessionController);

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
            Log.Information("{0}: Returned list of professions with {1} registers", thisController, result.Count().ToString());
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
                Log.Information("{0}: Returned profession {@result}", thisController, result);
                return Ok(result);
            }
            else
            {
                Log.Error("{0}: Returned null on searching by Id: {1}", thisController, id.ToString());
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
                Log.Information("{0}: Returned list of professions for searching with {1} registers with filter {2}", thisController, result.Count().ToString(), search);
            }
            else
            {
                Log.Error("{0}: Returned null on searching roles by filter: {1}", thisController, search);
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
        #endregion
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProfessionCreateDTO professionCreateDTO)
        {
            var command = new ProfessionCreateCommand { professionCreateDTO = professionCreateDTO };
            await _mediator.Send(command);
            Log.Information("{0}: Created profession {@profession}", thisController, professionCreateDTO);
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
                var queryPostUpdate = new ProfessionGetByIdQuery { Id = professionUpdateDTO.Id };
                var resultPostUpdate = await _mediator.Send(queryPostUpdate);
                Log.Information("{0}: Update profession Id: {id}. From {@result} to {@postUpdate}", thisController, professionUpdateDTO.Id.ToString(), result, resultPostUpdate);
                return Ok("Profession updated!");
            }
            else
            {
                Log.Error("{0}: Returned null on searching for update with Id: {1}", thisController, professionUpdateDTO.Id.ToString());
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
        /// <response code="400">Returns a error message stating why the request couldn't be executed</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var query = new ProfessionGetByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result != null)
            {
                var queryProfession = new PersonGetByProfessionQuery { Id = id };
                var resultProfession = await _mediator.Send(queryProfession);
                if (resultProfession.Count() > 0)
                {
                    Log.Error("{0}: Can't delete profession. The profession is currently related to {1} registers", thisController, resultProfession.Count().ToString());
                    return BadRequest("Can't delete profession. The profession is currently related to a person");
                }
                else
                {
                    var command = new ProfessionDeleteCommand { Id = id };
                    await _mediator.Send(command);
                    Log.Information("{0}: Deleted profession {@result}", thisController, result);
                    return Ok("Profession deleted!");
                }
            }
            else
            {
                Log.Error("{0}: Returned null on searching for delete by Id: {1}", thisController, id.ToString());
                return NotFound();
            }
        }
        #endregion
    }
}

using DecodeOficial.Application.Command;
using DecodeOficial.Application.DTO.Hobby;
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
    public class HobbyController : Controller
    {
        private readonly IMediator _mediator;

        public HobbyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Get
        #region Documentation
        /// <summary>
        /// Returns all the registered hobbies
        /// </summary>
        /// <returns>A list with all registered hobbies</returns>
        /// <remarks> The API returns a list with all registered hobbies</remarks>
        /// <response code="200">A list - full or empty - of hobbies </response>
        #endregion
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new HobbyGetAllQuery();
            var result = await _mediator.Send(query);
            Log.Information("HobbyController: Returned list of hobbies with {0} registers", result.Count().ToString());
            return Ok(result);
        }
        #endregion 

        #region Get {id}
        #region Documentation
        /// <summary>
        /// Search for a specific hobby based on the Id
        /// </summary>
        /// <param name="id">The Id of the hobby</param>
        /// <returns>The register corresponding to the informed Id</returns>
        /// <response code="200">Returns the register corresponding to the informed Id</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new HobbyGetByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result != null)
            {
                Log.Information("HobbyController: Returned hobby {@result}", result);
                return Ok(result);
            }
            else
            {
                Log.Error("HobbyController: Returned null on searching by Id: {0}", id.ToString());
                return NotFound();
            }
        }
        #endregion

        #region Search
        #region Documentation
        /// <summary>
        /// Searchs for the name of the registered hobby
        /// </summary>
        /// <param name="search">The name of the hobby</param>
        /// <returns>A list of hobbies whose name match the searched expression</returns>
        /// <response code="200">Returns a list -full or empty- of hobbies that match the searched expression</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("search/{search}")]
        public async Task<IActionResult> Search(string search)
        {
            var query = new HobbySearchQuery { Search = search };
            var result = await _mediator.Send(query);
            if (result.Count() != 0)
            {
                Log.Information("HobbyController: Returned list of hobbies for searching with {0} registers with filter {1}", result.Count().ToString(), search);
            }
            else
            {
                Log.Error("HobbyController: Returned null on searching roles by filter: {0}", search);
            }
            return Ok(result);
        }
        #endregion

        #region Create
        #region Documentation
        /// <summary>
        /// Create a hobby
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST
        ///     {
        ///        "name": "Reading"
        ///     }    
        /// </remarks>
        /// <param name="hobbyCreateDTO"></param>
        /// <returns>Confirmation message</returns>
        /// <response code="200">Returns a confirmation message</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] HobbyCreateDTO hobbyCreateDTO)
        {
            var command = new HobbyCreateCommand { hobbyCreateDTO = hobbyCreateDTO };
            await _mediator.Send(command);
            Log.Information("HobbyController: Created hobby {@hobby}", hobbyCreateDTO);
            return Ok("Hobby registered!");
        }
        #endregion

        #region Update
        #region Documentation
        /// <summary>
        /// Update a hobby
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "id": 1,
        ///        "name": "Reading"
        ///     }
        /// </remarks>
        /// <param name="hobbyUpdateDTO"></param>
        /// <returns>Confirmation message</returns>
        /// <response code="200">Returns a confirmation message</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] HobbyUpdateDTO hobbyUpdateDTO)
        {
            var query = new HobbyGetByIdQuery { Id = hobbyUpdateDTO.Id };
            var result = await _mediator.Send(query);

            if (result != null)
            {
                var command = new HobbyUpdateCommand { hobbyUpdateDTO = hobbyUpdateDTO };
                await _mediator.Send(command);
                var postUpdate = new PersonGetByIdQuery { Id = hobbyUpdateDTO.Id };
                Log.Information("HobbyController: Update hobby Id: {id}. From {@result} to {@postUpdate}", hobbyUpdateDTO.Id.ToString(), result, postUpdate);
                return Ok("Hobby updated!");
            }
            else
            {
                Log.Error("HobbyController: Returned null on searching for update with Id: {0}", hobbyUpdateDTO.Id.ToString());
                return NotFound();
            }
        }
        #endregion

        #region Delete
        #region Documentation
        /// <summary>
        /// Deletes a hobby
        /// </summary>
        /// <param name="id">The Id of the hobby</param>
        /// <returns>Confirmation message</returns>
        /// <response code="200">Returns a confirmation message</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var query = new HobbyGetByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result != null)
            {
                var query2 = new PeopleHobbiesGetByIdQuery { Id = id };
                var result2 = await _mediator.Send(query2);
                if (result2 != null)
                {
                    Log.Information("HobbyController: Unable to delete hobby {@result} due to existing associations", result);
                    return BadRequest("Unable to delete hobby due to existing associations!");
                }
                else
                {
                    var command = new HobbyDeleteCommand { Id = id };
                    await _mediator.Send(command);
                    Log.Information("HobbyController: Deleted hobby {@result}", result);
                    return Ok("Hobby deleted!");
                }
            }
            else
            {
                Log.Error("HobbyController: Returned null on searching for delete by Id: {0}", id.ToString());
                return NotFound();
            }
        }
        #endregion
    }
}

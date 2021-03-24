using DecodeOficial.Application.Command;
using DecodeOficial.Application.DTO.Person;
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
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;
        private const string thisController = nameof(PersonController);

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Get
        #region Documentation
        /// <summary>
        /// Returns all the registered people
        /// </summary>
        /// <returns>A list with all registered people</returns>
        /// <remarks> The API returns a list with all registered people</remarks>
        /// <response code="200">A list - full or empty - of people </response>
        #endregion
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new PersonGetAllQuery();
            var result = await _mediator.Send(query);
            Log.Information("{0}: Returned list of people with {1} registers", thisController, result.Count().ToString());
            return Ok(result);
        }
        #endregion 

        #region Get {id}
        #region Documentation
        /// <summary>
        /// Search for a specific person based on the Id
        /// </summary>
        /// <param name="id">The Id of the person</param>
        /// <returns>The register corresponding to the informed Id</returns>
        /// <response code="200">Returns the register corresponding to the informed Id</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new PersonGetByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result != null)
            {
                Log.Information("{0}: Returned person {@result}", thisController, result);
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
        /// Searchs for the first or last name of the registered people
        /// </summary>
        /// <param name="search">The first or last name of the person</param>
        /// <returns>A list of people whose first name or last name match the searched expression</returns>
        /// <response code="200">Returns a list -full or empty- of people that match the searched expression</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("search/{search}")]
        public async Task<IActionResult> Search(string search)
        {
            var query = new PersonSearchQuery { Search = search };
            var result = await _mediator.Send(query);
            if (result.Count() != 0)
            {
                Log.Information("{0}: Returned list of people for searching with {1} registers with filter {2}", thisController, result.Count().ToString(), search);
            }
            else
            {
                Log.Error("{0}: Returned null on searching names by filter: {1}", thisController, search);
            }
            return Ok(result);
        }
        #endregion

        #region Create
        #region Documentation
        /// <summary>
        /// Create a person
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST
        ///     {
        ///        "firstName": "John",
        ///        "lastName": "Doe",
        ///        "professionId": 0",
        ///        "birthDate": "1991-01-01",
        ///        "email": "johndoe@does.com",
        ///        "hobbies": [
        ///         {
        ///             "hobbyId": 0
        ///         },
        ///         {
        ///             "hobbyId": 0
        ///         }
        ///         ]
        ///     }
        /// </remarks>
        /// <param name="personCreateDTO"></param>
        /// <returns>Confirmation message</returns>
        /// <response code="200">Returns a confirmation message</response>
        /// <response code="400">Returns a error message stating why the request couldn't be executed</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonCreateDTO personCreateDTO)
        {
            foreach (var hobby in personCreateDTO.Hobbies)
            {
                var queryHobby = new HobbyGetByIdQuery { Id = hobby.HobbyId };
                var resulthobby = await _mediator.Send(queryHobby);
                if (resulthobby == null)
                {
                    Log.Error("{0}: Inexistent hobby with Id: {1}", thisController, hobby.HobbyId.ToString());
                    return BadRequest("Hobby Id " + hobby.HobbyId.ToString() + " does not exist");
                }
            }

            var queryProfession = new ProfessionGetByIdQuery {Id = personCreateDTO.ProfessionId };
            var resultProfession = await _mediator.Send(queryProfession);

            if (resultProfession == null)
            {
                Log.Error("{0}: Inexistent profession with Id: {1}", thisController, personCreateDTO.ProfessionId.ToString());
                return BadRequest("Inexistent profession");
            }
            else
            {
                var command = new PersonCreateCommand { personCreateDTO = personCreateDTO };
                await _mediator.Send(command);
                Log.Information("{0}: Created person {@person}", thisController, personCreateDTO);
                return Ok("Person registered!");
            }
        }
        #endregion

        #region Update
        #region Documentation
        /// <summary>
        /// Update a person
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "id": 1,
        ///        "firstName": "John",
        ///        "lastName": "Doe",
        ///        "professionId": 0",
        ///        "birthDate": "1991-01-01",
        ///        "email": "johndoe@does.com",
        ///        "hobbies": [
        ///         {
        ///             "hobbyId": 0
        ///         },
        ///         {
        ///             "hobbyId": 0
        ///         }
        ///         ],
        ///        "status": 1
        ///     }
        /// </remarks>
        /// <param name="personUpdateDTO"></param>
        /// <returns>Confirmation message</returns>
        /// <response code="200">Returns a confirmation message</response>
        /// <response code="400">Returns a error message stating why the request couldn't be executed</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PersonUpdateDTO personUpdateDTO)
        {
            foreach (var hobby in personUpdateDTO.Hobbies)
            {
                var queryHobby = new HobbyGetByIdQuery { Id = hobby.HobbyId };
                var resulthobby = await _mediator.Send(queryHobby);
                if (resulthobby == null)
                {
                    Log.Error("{0}: Inexistent hobby with Id: {1}", thisController, hobby.HobbyId.ToString());
                    return BadRequest("Hobby Id " + hobby.HobbyId.ToString() + " does not exist");
                }
            }

            var query = new PersonGetByIdQuery { Id = personUpdateDTO.Id };
            var result = await _mediator.Send(query);

            if (result != null)
            {
                var queryProfession = new ProfessionGetByIdQuery { Id = personUpdateDTO.ProfessionId };
                var resultProfession = await _mediator.Send(queryProfession);

                if (resultProfession == null)
                {
                    Log.Error("{0}: Inexistent profession with Id: {1}", thisController, personUpdateDTO.ProfessionId.ToString());
                    return NotFound("Inexistent profession");
                }
                else
                {
                    var command = new PersonUpdateCommand { personUpdateDTO = personUpdateDTO };
                    await _mediator.Send(command);
                    var postUpdate = new PersonGetByIdQuery { Id = personUpdateDTO.Id };
                    Log.Information("{0}: Update person Id: {id}. From {@result} to {@postUpdate}", thisController, personUpdateDTO.Id.ToString(), result, postUpdate);
                    return Ok("Person updated!");
                }
            }
            else
            {
                Log.Error("{0}: Returned null on searching for update with Id: {1}", thisController, personUpdateDTO.Id.ToString());
                return NotFound();
            }
        }
        #endregion

        #region Delete
        #region Documentation
        /// <summary>
        /// Deletes a person
        /// </summary>
        /// <param name="id">The Id of the person</param>
        /// <returns>Confirmation message</returns>
        /// <response code="200">Returns a confirmation message</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var query = new PersonGetByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result != null)
            {
                var command = new PersonDeleteCommand { Id = id };
                await _mediator.Send(command);
                Log.Information("{0}: Deleted person {@result}", thisController, result);
                return Ok("Person deleted!");
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

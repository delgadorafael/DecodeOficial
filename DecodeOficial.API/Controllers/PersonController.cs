using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DecodeOficial.Application.DTO;
using DecodeOficial.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DecodeOficial.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IApplicationServicePerson _applicationServicePerson;

        public PersonController(IApplicationServicePerson applicationServicePerson)
        {
            _applicationServicePerson = applicationServicePerson;
        }

        #region Get
        #region Documentation
        /// <summary>
        /// Returns all the people registered
        /// </summary>
        /// <returns>A ist with all registered people</returns>
        /// <remarks> The API returns a list -full or empty- with all registered people</remarks>
        /// <response code="200">Returns a list with all registered people</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            try
            {
                return Ok(await _applicationServicePerson.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<string>>> Get(int id)

        {
            try
            {
                var _person = await _applicationServicePerson.GetByIdAsync(id);
                if (_person == null)
                    return NotFound("Non-existent Id");

                return Ok(_person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
        /// <response code="200">Returns a list -full or empty- of people</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("search/{search}")]
        public async Task<ActionResult<IEnumerable<string>>> Search(string search)

        {
            try
            {
                var _search = await _applicationServicePerson.GetAllAsync();
                _search = _search.Where(    x => 
                                            x.FirstName.ToLower().Contains(search.ToLower())||
                                            x.LastName.ToLower().Contains(search.ToLower())
                                        );
                if (_search == null)
                    return NotFound();

                return Ok(_search);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
        ///        "id": 0,
        ///        "firstName": "John",
        ///        "lastName": "Doe",
        ///        "profession": "Accountant",
        ///        "birthDate": "1991-01-01",
        ///        "email": "johndoe@does.com",
        ///        "hobbies": "Math, Sudoku",
        ///        "status": 1
        ///     }
        /// </remarks>
        /// <param name="personDTO"></param>
        /// <returns>Confirmation message</returns>
        /// <response code="200">Returns a confirmation message</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonDTO personDTO)
        {
            try
            {
                if (personDTO == null)
                    return NotFound();

                await _applicationServicePerson.AddAsync(personDTO);
                //return CreatedAtRoute("Get", new { id = personDTO.Id }, personDTO);
                return Ok("Person registered!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
        ///        "profession": "Accountant",
        ///        "birthDate": "1991-01-01",
        ///        "email": "johndoe@does.com"
        ///        "hobbies": "Math, Sudoku",
        ///        "status": 1
        ///     }
        /// </remarks>
        /// <param name="personDTO"></param>
        /// <returns>Confirmation message</returns>
        /// <response code="200">Returns a confirmation message</response>
        /// <response code="404">If the item is null</response>
        #endregion
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PersonDTO personDTO)
        {
            try
            {
                if (personDTO == null)
                    return NotFound();

                //var _person = await _applicationServicePersonSearch.GetByIdAsync(personDTO.Id);
                //if (_person == null)
                //    return NotFound("Non-existent Id");

                await _applicationServicePerson.UpdateAsync(personDTO);
                return Ok("Person updated!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
        //[HttpDelete("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(PersonDTO personDTO)
        {
            try
            {
                //var _person = await _applicationServicePersonSearch.GetByIdAsync(id);
                //if (_person == null)
                //    return NotFound("Non-existent Id");

                await _applicationServicePerson.RemoveAsync(personDTO);
                return Ok("Person deleted!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

    }
}

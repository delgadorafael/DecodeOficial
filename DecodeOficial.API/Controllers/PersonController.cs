using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DecodeOficial.Application.DTO;
using DecodeOficial.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DecodeOficial.API.Controllers
{
    [Route("person/")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IApplicationServicePerson _applicationServicePerson;

        public PersonController(IApplicationServicePerson applicationServicePerson)
        {
            _applicationServicePerson = applicationServicePerson;
        }

        //GET api/values
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

        //GET api/value/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<string>>> Get(int id)

        {
            try
            {
                return Ok(await _applicationServicePerson.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //GET api/value/lastname
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
                return Ok(_search);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonDTO personDTO)
        {
            try
            {
                if (personDTO == null)
                    return NotFound();

                await _applicationServicePerson.AddAsync(personDTO);
                return Ok("Person registered!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //PUT api/values/1
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PersonDTO personDTO)
        {
            try
            {
                if (personDTO == null)
                    return NotFound();

                await _applicationServicePerson.UpdateAsync(personDTO);
                return Ok("Person updated!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //DELETE api/values/1
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] PersonDTO personDTO)
        {
            try
            {
                if (personDTO == null)
                    return NotFound();

                await _applicationServicePerson.RemoveAsync(personDTO);
                return Ok("Person deleted!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccinationManager.Models.Personne;
using VaccinationManager.Services.Personnes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VaccinationManager.Api.Controllers.Personne
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _repo;

        public PersonController(PersonService repo)
        {
            _repo = repo;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            try
            {
                return Ok(_repo.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "GetAll",
                    Message = ex.Message
                });
            }
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public ActionResult<Person> GetById(int id)
        {
            try
            {
                Person result = _repo.GetById(id);

                if (result is null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "GetById",
                    Message = ex.Message
                });
            }
        }

        // POST api/<PersonController>
        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person person)
        {
            try
            {
                if (person is null) return BadRequest();
                Person result = _repo.Insert(person);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "Post",
                    Message = ex.Message
                });
            }
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public ActionResult<Person> Put(int id, [FromBody] Person person)
        {
            try
            {
                if (person is null) return BadRequest();
                if (id != person.Id) return BadRequest();

                Person result = _repo.Update(person);
                if (result is null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "Put",
                    Message = ex.Message
                });
            }
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public ActionResult<Person> Delete(int id)
        {
            try
            {
                Person deletePerson = _repo.Delete(id);
                if (deletePerson is null) return NotFound();
                return Ok($"{deletePerson.FirstName} {deletePerson.LastName} a bien été supprimé");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "Delete",
                    Message = ex.Message
                });
            }
        }
    }
}

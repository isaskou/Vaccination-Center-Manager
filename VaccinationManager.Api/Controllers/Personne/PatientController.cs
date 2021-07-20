using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccinationManager.Models.Person;
using VaccinationManager.Services.Personnes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VaccinationManager.Api.Controllers.Personne
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _repo;

        public PatientController(PatientService repo)
        {
            _repo = repo;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetAll()
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

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public ActionResult<Patient> GetById(int id)
        {
            try
            {
                Patient result = _repo.GetById(id);

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

        // POST api/<PatientController>
        [HttpPost]
        public ActionResult<Patient> Post([FromBody] Patient patient)
        {
            try
            {
                if (patient is null) return BadRequest();

                Patient result = _repo.Insert(patient);
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

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public ActionResult<Patient> Put(int id, [FromBody] Patient patient)
        {
            try
            {
                if (patient is null) return BadRequest();
                if (id != patient.Id) return BadRequest();

                Patient result = _repo.Update(patient);
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

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public ActionResult<Patient> Delete(int id)
        {
            try
            {
                Patient result = _repo.Delete(id);
                if (result is null) return NotFound();

                return Ok($"Le patient {result.Person.FirstName} {result.Person.LastName} (id : {result.Id}) a bien été supprimé");
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

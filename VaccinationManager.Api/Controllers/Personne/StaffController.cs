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
    public class StaffController : ControllerBase
    {
        private readonly StaffService _repo;

        public StaffController(StaffService repo)
        {
            _repo = repo;
        }

        // GET: api/<StaffController>
        [HttpGet]
        public ActionResult<IEnumerable<Staff>> GetAll()
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

        // GET api/<StaffController>/5
        [HttpGet("{id}")]
        public ActionResult<Staff> GetById(int id)
        {
            try
            {
                Staff result = _repo.GetById(id);

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

        // POST api/<StaffController>
        [HttpPost]
        public ActionResult<Staff> Post([FromBody] Staff staff)
        {
            try
            {
                if (staff is null) return BadRequest();
                Staff result = _repo.Insert(staff);
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

        // PUT api/<StaffController>/5
        [HttpPut("{id}")]
        public ActionResult<Staff> Put(int id, [FromBody] Staff staff)
        {
            try
            {
                if (staff is null) return BadRequest();
                if (id != staff.Id) return BadRequest();

                Staff result = _repo.Update(staff);
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


        // DELETE api/<StaffController>/5
        [HttpDelete("{id}")]
        public ActionResult<Staff> Delete(int id)
        {
            try
            {
                Staff result = _repo.Delete(id);
                if (result is null) return NotFound();
                return Ok($"Le membre de staff {result.Id} a bien été supprimé");
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

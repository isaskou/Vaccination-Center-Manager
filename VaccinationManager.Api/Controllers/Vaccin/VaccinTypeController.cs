using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccinationManager.Models.Vaccin;
using VaccinationManager.Services.Vaccin;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VaccinationManager.Api.Controllers.Vaccin
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinTypeController : ControllerBase
    {
        private readonly VaccinTypeService _repo;

        public VaccinTypeController(VaccinTypeService repo)
        {
            _repo = repo;
        }

        // GET: api/<VaccinTypeController>
        [HttpGet]
        public ActionResult<IEnumerable<VaccinType>> GetAll()
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

        // GET api/<VaccinTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<VaccinType> GetById(int id)
        {
            try
            {
                VaccinType result = _repo.GetById(id);

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

        // POST api/<VaccinTypeController>
        [HttpPost]
        public ActionResult<VaccinType> Post([FromBody] VaccinType vaccinType)
        {
            try
            {
                if (vaccinType is null) return BadRequest();

                VaccinType result = _repo.Insert(vaccinType);

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

        // PUT api/<VaccinTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<VaccinType> Put(int id, [FromBody] VaccinType vaccinType)
        {
            try
            {
                if (vaccinType is null) return BadRequest();
                if (id != vaccinType.Id) return BadRequest();

                VaccinType result = _repo.Update(vaccinType);
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

        // DELETE api/<VaccinTypeController>/5
        [HttpDelete("{id}")]
        public ActionResult<VaccinType> Delete(int id)
        {
            try
            {
                VaccinType result = _repo.Delete(id);

                if (result is null) return NotFound();

                return Ok($"Le Vaccin de type {result.Name} a bien été supprimé");

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

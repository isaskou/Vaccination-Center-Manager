using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccinationManager.Models;
using VaccinationManager.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VaccinationManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutLogController : ControllerBase
    {
        private readonly OutLogService _repo;

        public OutLogController(OutLogService repo)
        {
            _repo = repo;
        }

        // GET: api/<OutLogController>
        [HttpGet]
        public ActionResult<IEnumerable<OutLog>> GetAll()
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

        // GET api/<OutLogController>/5
        [HttpGet("{id}")]
        public ActionResult<OutLog> GetById(int id)
        {
            try
            {
                OutLog result = _repo.GetById(id);

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

        // POST api/<OutLogController>
        [HttpPost]
        public ActionResult<OutLog> Post([FromBody] OutLog outlog)
        {
            try
            {
                if (outlog is null) return BadRequest();

                OutLog result = _repo.Insert(outlog);

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

        // PUT api/<OutLogController>/5
        [HttpPut("{id}")]
        public ActionResult<OutLog> Put(int id, [FromBody] OutLog outlog)
        {
            try
            {
                if (outlog is null) return BadRequest();
                if (id != outlog.Id) return BadRequest();

                OutLog result = _repo.Update(outlog);

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

        // DELETE api/<OutLogController>/5
        [HttpDelete("{id}")]
        public ActionResult<OutLog> Delete(int id)
        {
            try
            {
                OutLog result = _repo.Delete(id);
                if (result is null) return NotFound();

                return Ok($"Le log de sortie {result.Id} a bien été supprimé");
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

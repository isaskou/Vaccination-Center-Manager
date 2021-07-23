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
    public class InLogController : ControllerBase
    {
        private readonly InLogService _repo;

        public InLogController(InLogService repo)
        {
            _repo = repo;
        }

        // GET: api/<InLogController>
        [HttpGet]
        public ActionResult<IEnumerable<InLog>> GetAll()
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

        // GET api/<InLogController>/5
        [HttpGet("{id}")]
        public ActionResult<InLog> GetById(int id)
        {
            try
            {
                InLog result = _repo.GetById(id);

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

        // POST api/<InLogController>
        [HttpPost]
        public ActionResult<InLog> Post([FromBody] InLog inLog)
        {
            try
            {
                if (inLog is null) return BadRequest();

                InLog result = _repo.Insert(inLog);

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

        // PUT api/<InLogController>/5
        [HttpPut("{id}")]
        public ActionResult<InLog> Put(int id, [FromBody] InLog inLog)
        {
            try
            {
                if (inLog is null) return BadRequest();
                if (id != inLog.Id) return BadRequest();

                InLog result = _repo.Update(inLog);

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

        // DELETE api/<InLogController>/5
        [HttpDelete("{id}")]
        public ActionResult<InLog> Delete(int id)
        {
            try
            {
                InLog result = _repo.Delete(id);

                if (result is null) return NotFound();

                return Ok($"Le Log d'entrée {result.Id} a bien été supprimé");

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

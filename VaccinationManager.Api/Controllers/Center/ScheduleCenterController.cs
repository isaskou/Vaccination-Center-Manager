using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccinationManager.Models.Center;
using VaccinationManager.Services.Center;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VaccinationManager.Api.Controllers.Center
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleCenterController : ControllerBase
    {
        private readonly ScheduleCenterService _repo;

        public ScheduleCenterController(ScheduleCenterService repo)
        {
            _repo = repo;
        }

        // GET: api/<ScheduleCenterController>
        [HttpGet]
        public ActionResult<IEnumerable<ScheduleCenter>> GetAll()
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

        // GET api/<ScheduleCenterController>/5
        [HttpGet("{id}")]
        public ActionResult<ScheduleCenter> GetById(int id)
        {
            try
            {
                ScheduleCenter result = _repo.GetById(id);
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

        // POST api/<ScheduleCenterController>
        [HttpPost]
        public ActionResult<ScheduleCenter> Post(ScheduleCenter sc)
        {
            try
            {
                if (sc is null) return BadRequest();
                //var test = sc.OpenHour.ToString("t"); //cpnvert un date en hh:mm si tu veux hh:mm:ss tu dois mettre T
                //int i = 0;
                ScheduleCenter result = _repo.Insert(sc);
                return Ok(result);
                //return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
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

        // PUT api/<ScheduleCenterController>/5
        [HttpPut("{id}")]
        public ActionResult<ScheduleCenter> Put(int id, [FromBody] ScheduleCenter sc)
        {
            try
            {
                if (sc is null) return BadRequest();
                if (id != sc.Id) return BadRequest();

                ScheduleCenter result = _repo.Update(sc);
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

        // DELETE api/<ScheduleCenterController>/5
        [HttpDelete("{id}")]
        public ActionResult<ScheduleCenter> Delete(int id)
        {
            try
            {
                ScheduleCenter deletedSc = _repo.Delete(id);
                if (deletedSc is null) return NotFound();
                return Ok($"L'horaire {deletedSc.Id} a bien été supprimé");
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

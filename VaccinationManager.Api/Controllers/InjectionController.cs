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
    public class InjectionController : ControllerBase
    {
        private readonly InjectionService _repo;

        public InjectionController(InjectionService repo)
        {
            _repo = repo;
        }

        // GET: api/<InjectionController>
        [HttpGet]
        public ActionResult<IEnumerable<Injection>> GetAll()
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

        // GET api/<InjectionController>/5
        [HttpGet("{id}")]
        public ActionResult<Injection> GetById(int id)
        {
            try
            {
                Injection result = _repo.GetById(id);

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

        // POST api/<InjectionController>
        [HttpPost]
        public ActionResult<Injection> Post([FromBody] Injection injection)
        {
            try
            {
                if (injection is null) return BadRequest();

                Injection result = _repo.Insert(injection);
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

        // PUT api/<InjectionController>/5
        [HttpPut("{id}")]
        public ActionResult<Injection> Put(int id, [FromBody] Injection injection)
        {
            try
            {
                if (injection is null) return BadRequest();
                if (id != injection.Id) return BadRequest();

                Injection result = _repo.Update(injection);
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

        // DELETE api/<InjectionController>/5
        [HttpDelete("{id}")]
        public ActionResult<Injection> Delete(int id)
        {
            try
            {
                Injection result = _repo.Delete(id);

                if (result is null) return NotFound();

                return Ok($"L'injection {result.Id} a bien été supprimée");
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

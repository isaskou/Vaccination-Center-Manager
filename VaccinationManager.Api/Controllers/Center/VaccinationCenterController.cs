using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccinationManager.Models.Center;
using VaccinationManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using VaccinationManager.Services.Center;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VaccinationManager.Api.Controllers.Center
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationCenterController : ControllerBase
    {
        private readonly VaccinationCenterService _repo;

        public VaccinationCenterController(VaccinationCenterService repo)
        {
            _repo = repo;
        }

        // GET: api/<VaccinationCenterController>
        [HttpGet]
        public ActionResult<IEnumerable<VaccinationCenter>> GetAll()
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
        //// GET: api/<VaccinationCenterController>
        //[HttpGet]
        //public ActionResult<IEnumerable<VaccinationCenter>> GetFullAll()
        //{
        //    try
        //    {
        //        return Ok(_repo.GetFullAll());
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, new
        //        {
        //            Method = "GetFullAll",
        //            Message = ex.Message
        //        });
        //    }
        //}

        // GET api/<VaccinationCenterController>/5
        [HttpGet("{id}")]
        public ActionResult<VaccinationCenter> GetById(int id)
        {
            try
            {
                VaccinationCenter result = _repo.GetById(id);
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

        // POST api/<VaccinationCenterController>
        [HttpPost]
        public ActionResult<VaccinationCenter> Post([FromBody] VaccinationCenter vaccinationCenter)
        {
            try
            {
                if (vaccinationCenter is null) return BadRequest();
                VaccinationCenter result = _repo.Insert(vaccinationCenter);
                return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
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

        // PUT api/<VaccinationCenterController>/5
        [HttpPut("{id}")]
        public ActionResult<VaccinationCenter> Put(int id, [FromBody] VaccinationCenter vaccinationCenter)
        {
            try
            {
                if (vaccinationCenter is null) return BadRequest();
                if (id != vaccinationCenter.Id) return BadRequest();
                VaccinationCenter result = _repo.Update(vaccinationCenter);
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

        // DELETE api/<VaccinationCenterController>/5
        [HttpDelete("{id}")]
        public ActionResult<VaccinationCenter> Delete(int id)
        {
            try
            {
                VaccinationCenter vc = _repo.Delete(id);
                if (vc is null) return NotFound();

                return Ok($"Le centre {vc.Name} a bien été supprimé");
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

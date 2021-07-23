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
    public class VaccinLotController : ControllerBase
    {
        private readonly VaccinLotService _repo;

        public VaccinLotController(VaccinLotService repo)
        {
            _repo = repo;
        }

        // GET: api/<VaccinLotController>
        [HttpGet]
        public ActionResult<IEnumerable<VaccinLot>> GetAll()
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

        // GET api/<VaccinLotController>/5
        [HttpGet("{id}")]
        public ActionResult<VaccinLot> GetById(int id)
        {
            try
            {
                VaccinLot result = _repo.GetById(id);

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

        // POST api/<VaccinLotController>
        [HttpPost]
        public ActionResult<VaccinLot> Post([FromBody] VaccinLot vaccinLot)
        {
            try
            {
                if (vaccinLot is null) return BadRequest();
                VaccinLot result = _repo.Insert(vaccinLot);
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

        // PUT api/<VaccinLotController>/5
        [HttpPut("{id}")]
        public ActionResult<VaccinLot> Put(int id, [FromBody] VaccinLot vaccinLot)
        {
            try
            {
                if (vaccinLot is null) return BadRequest();
                if (id != vaccinLot.Id) return BadRequest();

                VaccinLot result = _repo.Update(vaccinLot);

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

        // DELETE api/<VaccinLotController>/5
        [HttpDelete("{id}")]
        public ActionResult<VaccinLot> Delete(int id)
        {
            try
            {
                VaccinLot result = _repo.Delete(id);

                if (result is null) return NotFound();

                return Ok($"Le lot de vaccin {result.Id} a bien été supprimé");
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

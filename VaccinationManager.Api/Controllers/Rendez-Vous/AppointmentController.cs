using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccinationManager.Models.RendezVous;
using VaccinationManager.Services.Rendez_vous;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VaccinationManager.Api.Controllers.Rendez_Vous
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService _repo;

        public AppointmentController(AppointmentService repo)
        {
            _repo = repo;
        }

        // GET: api/<AppointmentController>
        [HttpGet]
        public ActionResult<IEnumerable<Appointment>> GetAll()
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

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public ActionResult<Appointment> GetById(int id)
        {
            try
            {
                Appointment result = _repo.GetById(id);

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

        // POST api/<AppointmentController>
        [HttpPost]
        public ActionResult<Appointment> Post([FromBody] Appointment appointment)
        {
            try
            {
                if (appointment is null) return BadRequest();

                Appointment result = _repo.Insert(appointment);
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

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public ActionResult<Appointment> Put(int id, [FromBody] Appointment appointment)
        {
            try
            {
                if (appointment is null) return BadRequest();
                if (id != appointment.Id) return BadRequest();

                Appointment result = _repo.Update(appointment);
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

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public ActionResult<Appointment> Delete(int id)
        {
            try
            {
                Appointment result = _repo.Delete(id);
                if (result is null) return NotFound();

                return Ok($"Le rendez-vous {result.Id} a été supprimé");
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

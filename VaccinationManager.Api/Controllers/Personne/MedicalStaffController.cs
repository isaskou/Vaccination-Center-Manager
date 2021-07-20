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
    public class MedicalStaffController : ControllerBase
    {
        private readonly MedicalStaffService _repo;

        public MedicalStaffController(MedicalStaffService repo)
        {
            _repo = repo;
        }


        // GET: api/<MedicalStaffController>
        [HttpGet]
        public ActionResult<IEnumerable<MedicalStaff>> GetAll()
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

        // GET api/<MedicalStaffController>/5
        [HttpGet("{id}")]
        public ActionResult<MedicalStaff> GetById(int id)
        {
            try
            {
                MedicalStaff result = _repo.GetById(id);

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

        // POST api/<MedicalStaffController>
        [HttpPost]
        public ActionResult<MedicalStaff> Post([FromBody] MedicalStaff medicalStaff)
        {
            try
            {
                if (medicalStaff is null) return BadRequest();
                MedicalStaff result = _repo.Insert(medicalStaff);
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

        // PUT api/<MedicalStaffController>/5
        [HttpPut("{id}")]
        public ActionResult<MedicalStaff> Put(int id, [FromBody] MedicalStaff medicalStaff)
        {
            try
            {
                if (medicalStaff is null) return BadRequest();
                if (id != medicalStaff.Id) return BadRequest();

                MedicalStaff result = _repo.Update(medicalStaff);
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

        // DELETE api/<MedicalStaffController>/5
        [HttpDelete("{id}")]
        public ActionResult<MedicalStaff> Delete(int id)
        {
            try
            {
                MedicalStaff result = _repo.Delete(id);
                if (result is null) return NotFound();
                return Ok($"Le medical staff {result.Id} a bien été supprimé");
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

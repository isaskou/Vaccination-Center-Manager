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
    public class VaccinProviderController : ControllerBase
    {
        private readonly VaccinProviderService _repo;

        public VaccinProviderController(VaccinProviderService repo)
        {
            _repo = repo;
        }

        // GET: api/<VaccinProviderController>
        [HttpGet]
        public ActionResult<IEnumerable<VaccinProvider>> GetAll()
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

        // GET api/<VaccinProviderController>/5
        [HttpGet("{id}")]
        public ActionResult<VaccinProvider> GetById(int id)
        {
            try
            {
                VaccinProvider result = _repo.GetById(id);

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

        // POST api/<VaccinProviderController>
        [HttpPost]
        public ActionResult<VaccinProvider> Post([FromBody] VaccinProvider vaccinProvider)
        {
            try
            {
                if (vaccinProvider is null) return BadRequest();

                VaccinProvider result = _repo.Insert(vaccinProvider);
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

        // PUT api/<VaccinProviderController>/5
        [HttpPut("{id}")]
        public ActionResult<VaccinProvider> Put(int id, [FromBody] VaccinProvider vaccinProvider)
        {
            try
            {
                if (vaccinProvider is null) return BadRequest();
                if (id != vaccinProvider.Id) return BadRequest();

                VaccinProvider result = _repo.Update(vaccinProvider);

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

        // DELETE api/<VaccinProviderController>/5
        [HttpDelete("{id}")]
        public ActionResult<VaccinProvider> Delete(int id)
        {
            try
            {
                VaccinProvider result = _repo.Delete(id);

                if (result is null) return NotFound();

                return Ok($"Le vaccinProvider {result.Name} a bien été supprimé");
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

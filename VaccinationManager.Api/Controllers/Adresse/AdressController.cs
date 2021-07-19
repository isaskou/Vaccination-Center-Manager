using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccinationManager.Models.Adresse;
using VaccinationManager.Services.Adresse;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VaccinationManager.Api.Controllers.Adresse
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly AdressService _repo;

        public AdressController(AdressService repo)
        {
            _repo = repo;
        }

        // GET: api/<AdressController>
        [HttpGet]

        public ActionResult<IEnumerable<Adress>> GetAll()
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

        // GET api/<AdressController>/5
        [HttpGet("{id}")]
        public ActionResult<Adress> GetById(int id)
        {
            try
            {
                Adress adress = _repo.GetById(id);
                if (adress is null) return NotFound();
                return Ok(adress);
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

        // POST api/<AdressController>
        [HttpPost]
        public ActionResult<Adress> Post([FromBody] Adress adress)
        {
            try
            {
                if (adress is null) return BadRequest();
                Adress result = _repo.Insert(adress);
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

        // PUT api/<AdressController>/5
        [HttpPut("{id}")]
        public ActionResult<Adress> Put(int id, [FromBody] Adress adress)
        {
            try
            {
                if (adress is null) return BadRequest();
                if (id != adress.Id) return BadRequest();

                Adress result = _repo.Update(adress);
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

        // DELETE api/<AdressController>/5
        [HttpDelete("{id}")]
        public ActionResult<Adress> Delete(int id)
        {
            try
            {
                Adress deletedAdress = _repo.Delete(id);
                if (deletedAdress is null) return NotFound();
                return Ok($"L'adresse {deletedAdress.Id} a bien été supprimée");
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

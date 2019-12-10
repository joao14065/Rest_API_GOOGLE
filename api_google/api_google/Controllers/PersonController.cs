using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_google.Business;
using api_google.Model;
using Microsoft.AspNetCore.Mvc;

namespace api_google.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
        //Declaração do serviço usado
        private IPersonBusiness _personBusiness;
        public PersonController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll().ToList());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Usuario person)
        {
            if (person == null) return BadRequest();
            if (_personBusiness.Create(person)) return Ok(person);
            else return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (_personBusiness.Delete(id)) return NoContent();
            else return BadRequest();
        }
    }
}

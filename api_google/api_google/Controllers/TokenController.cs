using api_google.Business;
using api_google.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace api_google.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IPersonBusiness _personBusiness;

        public TokenController(IPersonBusiness personBusiness, IConfiguration configuration)
        {
            _personBusiness = personBusiness;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult RequestToken([FromBody] Usuario model)
        {
            var user = _personBusiness.Find(p => !p.Excluido && p.Email == model.Email && p.Senha == model.Senha).FirstOrDefault();
            if (user != null)
            {
                var expiration = DateTime.UtcNow.AddHours(1);
               var response =  _personBusiness.GetToken(model.Email, expiration);

                if (response.Contains("Falha"))
                {
                    return BadRequest("Falha na requisição");

                }
                else
                {
                    return Ok(new
                    {
                        Token = response,
                        Expiration = expiration
                    });
                }
                
            }
            return BadRequest("Credenciais inválidas.");
        }

    }
}

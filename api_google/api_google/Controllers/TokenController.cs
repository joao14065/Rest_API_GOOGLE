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
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, model.Email),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                // tempo de expiração do token: 1 hora
                var expiration = DateTime.UtcNow.AddHours(1);
                JwtSecurityToken token = new JwtSecurityToken(
                   issuer: null,
                   audience: null,
                   claims: claims,
                   expires: expiration,
                   signingCredentials: creds);

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = expiration
                });
            }
            return BadRequest("Credenciais inválidas.");
        }

    }
}

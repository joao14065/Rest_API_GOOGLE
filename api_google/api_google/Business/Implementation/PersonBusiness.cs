using api_google.Model;
using api_google.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace api_google.Business.Implementation
{
    public class PersonBusiness : IPersonBusiness
    {
        private readonly IConfiguration _configuration;

        private IRepository<Usuario> _repository;
        public PersonBusiness(IRepository<Usuario> repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public bool Create(Usuario item)
        {
            return _repository.Save(item);
        }

        public bool Delete(long Id)
        {
            return _repository.Delete(Id);
        }

        public IQueryable<Usuario> FindAll()
        {
            return _repository.FindAll();
        }

        public Usuario FindById(long Id)
        {
            return _repository.Find(Id);
        }

        public IQueryable<Usuario> Find(Expression<Func<Usuario, bool>> where, bool somenteLeitura = false)
        {
            return _repository.Find(where);
        }

        public string GetToken(string Email, DateTime expiration)
        {
            try
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, Email),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                // tempo de expiração do token: 1 hora
                JwtSecurityToken token = new JwtSecurityToken(
                   issuer: null,
                   audience: null,
                   claims: claims,
                   expires: expiration,
                   signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (SecurityTokenException e)
            {
                return "Falha - " + e.Message;
            }
        }
    }
}

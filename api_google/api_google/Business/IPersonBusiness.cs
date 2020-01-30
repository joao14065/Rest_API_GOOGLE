using api_google.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api_google.Business
{
    public interface IPersonBusiness
    {
        bool Create(Usuario Person);
        Usuario FindById(long Id);
        IQueryable<Usuario> Find(Expression<Func<Usuario, bool>> where, bool somenteLeitura = false);
        IQueryable<Usuario> FindAll();
        string GetToken(string Email, DateTime expiration);
        bool Delete(long Id);
    }
}

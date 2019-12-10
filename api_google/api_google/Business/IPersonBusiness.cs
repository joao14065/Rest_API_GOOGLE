using api_google.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_google.Business
{
    public interface IPersonBusiness
    {
        bool Create(Usuario Person);
        Usuario FindById(long Id);
        IQueryable<Usuario> FindAll();
        bool Delete(long Id);
    }
}

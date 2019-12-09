using api_google.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_google.Business
{
    public interface IPersonBusiness
    {
        bool Create(Person Person);
        Person FindById(long Id);
        IQueryable<Person> FindAll();
        bool Delete(long Id);
    }
}

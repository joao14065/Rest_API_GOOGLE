using api_google.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_google.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person Person);
        Person FindById(long Id);
        List<Person> FindAll();
        Person Update(Person Person);
        void Delete(long Id);
    }
}

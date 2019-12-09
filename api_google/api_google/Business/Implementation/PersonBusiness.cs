using api_google.Model;
using api_google.Repository;
using System.Collections.Generic;

namespace api_google.Business.Implementation
{
    public class PersonBusiness : IPersonBusiness
    {
        private IRepository<Person> _repository;
        public PersonBusiness(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public Person Create(Person item)
        {
            return _repository.Create(item);
        }

        public void Delete(long Id)
        {
            _repository.Delete(Id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long Id)
        {
            return _repository.FindById(Id);
        }

        public Person Update(Person item)
        {
            return _repository.Update(item);
        }
    }
}

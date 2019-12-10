using api_google.Model;
using api_google.Repository;
using System.Collections.Generic;
using System.Linq;

namespace api_google.Business.Implementation
{
    public class PersonBusiness : IPersonBusiness
    {
        private IRepository<Usuario> _repository;
        public PersonBusiness(IRepository<Usuario> repository)
        {
            _repository = repository;
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
    }
}

using api_google.Model.Base;
using System.Collections.Generic;

namespace api_google.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long Id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long Id);
        bool Exist(long id);
    }
}

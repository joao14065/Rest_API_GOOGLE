using api_google.Model.Base;
using System.Linq;

namespace api_google.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        bool Save(T item);
        T Find(long Id);
        IQueryable<T> FindAll(bool somenteLeitura = false);
        bool Delete(long Id);
        bool Exist(long id);
    }
}

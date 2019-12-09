using api_google.Context;
using api_google.Model.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace api_google.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PostgreSQLContext _context;
        private DbSet<T> dataset;
        private ArrayList _listaViolacacao;

        public ArrayList ListaViolacao { get { return _listaViolacacao; } }

        public Repository(PostgreSQLContext context)
        {
            _context = context;
            dataset = context.Set<T>();
        }
        private Repository()
        {
            _listaViolacacao = new ArrayList();
        }

        public bool Save(T item)
        {
            try
            {
                if (Exist(item.Id))
                {
                    item.DataAlteracao = DateTime.Now;
                    _context.Entry(item).State = EntityState.Modified;
                }
                else
                {
                    item.DataCriacao = DateTime.Now;
                    item.DataAlteracao = DateTime.Now;
                    _context.Set<T>().Add(item);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    _listaViolacacao.Add(ex.InnerException.Message);
                else
                    _listaViolacacao.Add(ex.Message);
                return false;
            }
            bool ok = _context.SaveChanges() > 0;
            _context.SaveChanges();
            return ok;
        }

        public bool Delete(long Id)
        {
            SetDeleted(Find(Id));

            var recordCount = _context.SaveChanges();
            return (recordCount > 0);
        }
        private void SetDeleted(T entity)
        {
            //dataContext.Set<T>().Remove(entity);
            entity.Excluido = true;
            entity.DataAlteracao = DateTime.Now;
        }
        public bool Exist(long id)
        {
            return dataset.Any(p => p.Id == id);
        }

        public IQueryable<T> FindAll(bool somenteLeitura = false)
        {
            if (somenteLeitura)
                return _context.Set<T>().AsNoTracking();
            else
                return _context.Set<T>();
        }

        public T Find(long Id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(Id));
        }
        public virtual IQueryable<T> Find(Expression<Func<T, bool>> where, bool somenteLeitura = false)
        {
            if (somenteLeitura)
                return _context.Set<T>().Where(where).AsNoTracking();
            else
                return _context.Set<T>().Where(where);
        }
    }
}

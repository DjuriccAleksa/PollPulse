
using PollPulse.Entities.Models.Base;
using PollPulse.Repository.Context;
using PollPulse.Repository.Interfaces.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Repository.Base_repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly RepositoryContext _context;

        public Repository(RepositoryContext context) => _context = context;

        public IQueryable<T> GetAll() => _context.Set<T>();
        public IQueryable<T> GetByCodition(Expression<Func<T, bool>> condition) => _context.Set<T>().Where(condition);
        public void Create(T entity) => _context.Add(entity);
        public void Update(T entity) => _context.Update(entity);
        public void Delete(T entity) => _context.Remove(entity);
    }
}

using PollPulse.Entities.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Repository.Interfaces.BaseRepository
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetByCodition(Expression<Func<T,bool>> condition);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

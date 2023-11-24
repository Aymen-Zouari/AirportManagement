using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public Service(IUnitOfWork unitOfWork)
        {
            this._repository = unitOfWork.Repository<T>();
            this._unitOfWork = unitOfWork;
        }
        public virtual void Add(T entity)
        {
            _unitOfWork.Repository<T>().Add(entity);   
        }
        public virtual void Update(T entity)
        {
            _unitOfWork.Repository<T>().Update(entity);
        }
        public virtual void Delete(T entity)
        {
            _unitOfWork.Repository<T>().Delete(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
           _unitOfWork.Repository<T>().Delete(where);
        }
        public virtual T GetById(object id)
        {
            return _unitOfWork.Repository<T>().GetById(id);
        }
        public virtual T GetById(string id)
        {
            return _unitOfWork.Repository<T>().GetById(id);

        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> filter = null)
        {
            return _unitOfWork.Repository<T>().GetMany(filter);
        }
        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return _unitOfWork.Repository<T>().Get(where);
        }
        public void Commit()
        {
            try
            {
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}

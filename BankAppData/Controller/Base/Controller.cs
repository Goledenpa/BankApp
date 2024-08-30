using BankAppData.DB;
using BankAppData.Repository.Base;
using BankAppData.UnitOfWork;

namespace BankAppData.Controller.Base
{

    /// <summary>
    /// Base controller class for all controllers
    /// </summary>
    /// <typeparam name="TDatabase"></typeparam>
    public abstract class Controller<TDatabase> : IController<TDatabase>
        where TDatabase : class, new()
    {
        protected readonly IRepository<TDatabase> _repository;
        protected readonly IUnitOfWork<BankContext> _unitOfWork;

        protected Controller(IUnitOfWork<BankContext> unitOfWork, IRepository<TDatabase> repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public virtual TDatabase Add(TDatabase entity)
        {
            try
            {
                _unitOfWork.CreateTransaction();

                _repository.Add(entity);

                _unitOfWork.Save();
                _unitOfWork.Commit();

                return entity;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
            }

            return null;
        }

        public virtual bool Delete(int id)
        {
            try
            {
                _unitOfWork.CreateTransaction();

                _repository.Delete(id);

                _unitOfWork.Save();
                _unitOfWork.Commit();

                return true;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
            }

            return false;
        }

        public virtual TDatabase? Get(int id)
        {
            return _repository.Get(id);
        }

        public virtual IEnumerable<TDatabase> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TDatabase Update(TDatabase entity)
        {
            try
            {
                _unitOfWork.CreateTransaction();

                entity = _repository.Update(entity);

                _unitOfWork.Save();
                _unitOfWork.Commit();

                return entity;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                return null;
            }
        }
    }
}

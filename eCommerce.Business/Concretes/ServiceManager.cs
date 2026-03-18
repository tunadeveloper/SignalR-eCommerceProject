using eCommerce.Business.Abstracts;
using eCommerce.DataAccess.Repositories;
using eCommerce.DataAccess.UnitOfWorks;
using eCommerce.Entity.Entities;
using System.Linq.Expressions;

namespace eCommerce.Business.Concretes
{
    public class ServiceManager : IServiceService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Service> _repository;

        public ServiceManager(IUnitOfWork uow)
        {
            _uow = uow;
            _repository = _uow.Services;
        }

        public async Task<Service> GetByIdAsyncBL(int id)
            => await _repository.GetByIdAsync(id);

        public async Task<List<Service>> GetListBL()
            => await _repository.GetList();

        public async Task<List<Service>> GetListByFilterAsyncBL(Expression<Func<Service, bool>> filter)
            => await _repository.GetListByFilterAsync(filter);

        public async Task<List<Service>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

        public async Task<List<Service>> GetPagedAsyncBL(int page, int pageSize)
             => await _repository.GetPagedAsync(page, pageSize);

        public async Task InsertAsyncBL(Service entity)
        {
            await _repository.InsertAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsyncBL(Service entity)
        {
            await _repository.UpdateAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsyncBL(Service entity)
        {
            await _repository.DeleteAsync(entity);
            await _uow.SaveAsync();
        }
    }
}

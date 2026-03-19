using eCommerce.Business.Abstracts;
using eCommerce.DataAccess.Repositories;
using eCommerce.DataAccess.UnitOfWorks;
using eCommerce.Entity.Entities;
using System.Linq.Expressions;

namespace eCommerce.Business.Concretes
{
    public class ContactManager : IContactService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Contact> _repository;

        public ContactManager(IUnitOfWork uow)
        {
            _uow = uow;
            _repository = _uow.Contacts;
        }

        public async Task<List<Contact>> GetListBL(params Expression<Func<Contact, object>>[] includes)
            => await _repository.GetList(includes);

        public async Task<Contact> GetByIdAsyncBL(int id, params Expression<Func<Contact, object>>[] includes)
            => await _repository.GetByIdAsync(id, includes);

        public async Task<List<Contact>> GetListByFilterAsyncBL(Expression<Func<Contact, bool>> filter, params Expression<Func<Contact, object>>[] includes)
            => await _repository.GetListByFilterAsync(filter, includes);

        public async Task<List<Contact>> GetPagedAsyncBL(int page, int pageSize, params Expression<Func<Contact, object>>[] includes)
             => await _repository.GetPagedAsync(page, pageSize, includes);

        public async Task<List<Contact>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

        public async Task InsertAsyncBL(Contact entity)
        {
            await _repository.InsertAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsyncBL(Contact entity)
        {
            await _repository.UpdateAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsyncBL(Contact entity)
        {
            await _repository.DeleteAsync(entity);
            await _uow.SaveAsync();
        }
        public async Task<int> GetCountAsyncBL()
        {
            return await _repository.GetCountAsync();
        }
    }
}

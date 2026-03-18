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

        public async Task<Contact> GetByIdAsyncBL(int id)
            => await _repository.GetByIdAsync(id);

        public async Task<List<Contact>> GetListBL()
            => await _repository.GetList();

        public async Task<List<Contact>> GetListByFilterAsyncBL(Expression<Func<Contact, bool>> filter)
            => await _repository.GetListByFilterAsync(filter);

        public async Task<List<Contact>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

        public async Task<List<Contact>> GetPagedAsyncBL(int page, int pageSize)
             => await _repository.GetPagedAsync(page, pageSize);

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
    }
}

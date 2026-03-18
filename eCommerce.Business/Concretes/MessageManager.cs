using eCommerce.Business.Abstracts;
using eCommerce.DataAccess.Repositories;
using eCommerce.DataAccess.UnitOfWorks;
using eCommerce.Entity.Entities;
using System.Linq.Expressions;

namespace eCommerce.Business.Concretes
{
    public class MessageManager : IMessageService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Message> _repository;

        public MessageManager(IUnitOfWork uow)
        {
            _uow = uow;
            _repository = _uow.Messages;
        }

        public async Task<Message> GetByIdAsyncBL(int id)
            => await _repository.GetByIdAsync(id);

        public async Task<List<Message>> GetListBL()
            => await _repository.GetList();

        public async Task<List<Message>> GetListByFilterAsyncBL(Expression<Func<Message, bool>> filter)
            => await _repository.GetListByFilterAsync(filter);

        public async Task<List<Message>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

        public async Task<List<Message>> GetPagedAsyncBL(int page, int pageSize)
             => await _repository.GetPagedAsync(page, pageSize);

        public async Task InsertAsyncBL(Message entity)
        {
            await _repository.InsertAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsyncBL(Message entity)
        {
            await _repository.UpdateAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsyncBL(Message entity)
        {
            await _repository.DeleteAsync(entity);
            await _uow.SaveAsync();
        }
    }
}

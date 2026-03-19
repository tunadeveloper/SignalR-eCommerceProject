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

        public async Task<List<Message>> GetListBL(params Expression<Func<Message, object>>[] includes)
            => await _repository.GetList(includes);

        public async Task<Message> GetByIdAsyncBL(int id, params Expression<Func<Message, object>>[] includes)
            => await _repository.GetByIdAsync(id, includes);

        public async Task<List<Message>> GetListByFilterAsyncBL(Expression<Func<Message, bool>> filter, params Expression<Func<Message, object>>[] includes)
            => await _repository.GetListByFilterAsync(filter, includes);

        public async Task<List<Message>> GetPagedAsyncBL(int page, int pageSize, params Expression<Func<Message, object>>[] includes)
             => await _repository.GetPagedAsync(page, pageSize, includes);

        public async Task<List<Message>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

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

        public async Task<int> GetCountAsyncBL()
        {
            return await _repository.GetCountAsync();
        }
    }
}

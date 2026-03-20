using eCommerce.Business.Abstracts;
using eCommerce.DataAccess.Abstracts;
using eCommerce.DataAccess.UnitOfWorks;
using eCommerce.Entity.Entities;
using System.Linq.Expressions;

namespace eCommerce.Business.Concretes
{
    public class PaymentTransactionManager : IPaymentTransactionService
    {
        private readonly IUnitOfWork _uow;
        private readonly IPaymentTransaction _repository;

        public PaymentTransactionManager(IUnitOfWork uow)
        {
            _uow = uow;
            _repository = _uow.PaymentTransactions;
        }

        public async Task<List<PaymentTransaction>> GetListBL(params Expression<Func<PaymentTransaction, object>>[] includes)
            => await _repository.GetList(includes);

        public async Task<PaymentTransaction> GetByIdAsyncBL(int id, params Expression<Func<PaymentTransaction, object>>[] includes)
            => await _repository.GetByIdAsync(id, includes);

        public async Task<List<PaymentTransaction>> GetListByFilterAsyncBL(Expression<Func<PaymentTransaction, bool>> filter, params Expression<Func<PaymentTransaction, object>>[] includes)
            => await _repository.GetListByFilterAsync(filter, includes);

        public async Task<List<PaymentTransaction>> GetPagedAsyncBL(int page, int pageSize, params Expression<Func<PaymentTransaction, object>>[] includes)
            => await _repository.GetPagedAsync(page, pageSize, includes);

        public async Task<List<PaymentTransaction>> GetListNoTrackingAsyncBL()
            => await _repository.GetListNoTrackingAsync();

        public async Task InsertAsyncBL(PaymentTransaction entity)
        {
            await _repository.InsertAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsyncBL(PaymentTransaction entity)
        {
            await _repository.UpdateAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsyncBL(PaymentTransaction entity)
        {
            await _repository.DeleteAsync(entity);
            await _uow.SaveAsync();
        }

        public async Task<int> GetCountAsyncBL()
            => await _repository.GetCountAsync();
    }
}


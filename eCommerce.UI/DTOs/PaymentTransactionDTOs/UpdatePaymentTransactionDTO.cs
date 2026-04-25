namespace eCommerce.UI.DTOs.PaymentTransactionDTOs
{
    public class UpdatePaymentTransactionDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsSuccessful { get; set; }
    }
}

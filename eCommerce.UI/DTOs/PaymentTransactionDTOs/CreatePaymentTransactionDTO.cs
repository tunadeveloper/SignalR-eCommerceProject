namespace eCommerce.UI.DTOs.PaymentTransactionDTOs
{
    public class CreatePaymentTransactionDTO
    {
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsSuccessful { get; set; }
    }
}

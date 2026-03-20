namespace eCommerce.DTO.DTOs.PaymentTransactionDTOs
{
    public class ResultPaymentTransactionDTO
    {
        public string Id { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsSuccessful { get; set; }
        public string CustomerName { get; set; }
    }
}


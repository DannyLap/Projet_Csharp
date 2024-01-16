namespace projetApi.Models
{
    public class Invoices
    {
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        public int CommandId { get; set; }
        public decimal InvoiceTotalAmount { get; set; }
        public User User { get; set; }
        public Command Command { get; set; }
    }
}
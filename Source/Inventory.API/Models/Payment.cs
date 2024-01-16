namespace projetApi.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public string PaymentMethod { get; set; }
        public User User { get; set; }
    }
}
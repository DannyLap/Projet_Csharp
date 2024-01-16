namespace projetApi.Models
{
    public class Command
    {
        public int CommandId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int CommandQuantity { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
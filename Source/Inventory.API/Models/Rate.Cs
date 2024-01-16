namespace projetApi.Models
{
    public class Rate
    {
        public int RateId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int RateRating { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
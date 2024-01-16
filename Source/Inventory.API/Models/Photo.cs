 namespace projetApi.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string PhotoUrl { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
    // Address.cs
namespace projetApi.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressPostalCode { get; set; }

        // Propriété de navigation
        public User User { get; set; }
    }
}
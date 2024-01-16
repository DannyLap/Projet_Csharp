// User.cs
using System.Collections.Generic;

namespace projetApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }

        // Propriétés de navigation
        public Address Address { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Command> Commands { get; set; }
        public List<Invoices> Invoices { get; set; }
        public List<Photo> Photos { get; set; }
        public List<Rate> Rates { get; set; }
        public List<Payment> Payments { get; set; }
    }
}


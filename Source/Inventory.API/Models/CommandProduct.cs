namespace projetApi.Models
{
    public class CommandProduct
    {
        public int CommandId { get; set; }
        public int ProductId { get; set; }
        public int CommandProductQuantity { get; set; }
        public Command Command { get; set; }
        public Product Product { get; set; }
    }
}
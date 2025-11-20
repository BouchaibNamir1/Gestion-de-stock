namespace Gestion_de_stock.Models
{
    public class Service
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public required string Description { get; set; }
        public decimal Prix { get; set; }
    }

}

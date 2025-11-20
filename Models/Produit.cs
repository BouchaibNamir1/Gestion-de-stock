using System.ComponentModel.DataAnnotations.Schema;
namespace Gestion_de_stock.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public required string Description { get; set; }
        public int Stock { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Prix { get; set; }
    }
}
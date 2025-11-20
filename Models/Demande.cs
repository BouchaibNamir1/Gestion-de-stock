namespace Gestion_de_stock.Models
{
    public class Demande
    {
        public int Id { get; set; }
        public required string CliniqueNom { get; set; }
        public required string TypeDemande { get; set; } // "Produit" ou "Service"
        public required string Description { get; set; }
        public required string Statut { get; set; } = "Non Traité";
        public DateTime DateDemande { get; set; } = DateTime.Now;
    }

}

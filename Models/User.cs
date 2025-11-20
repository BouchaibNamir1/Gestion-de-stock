namespace Gestion_de_stock.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; } // Pas encore hashé ici
        public required string Role { get; set; } // "Admin" ou "Clinique"
    }
}
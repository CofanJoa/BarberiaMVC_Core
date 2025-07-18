using System.ComponentModel.DataAnnotations;

namespace BarberiaMVC_Core.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public required string Nombre { get; set; }

        [Required]
        public required string Apellido { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string ContrasenaHash { get; set; }

        [Required]
        public required string Rol { get; set; } // "Admin", "Cliente", "Barbero"
    }
}

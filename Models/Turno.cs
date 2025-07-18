using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberiaMVC_Core.Models
{
    public class Turno
    {
        public int Id { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public required Cliente Cliente { get; set; }

        [Required]
        public int IdBarbero { get; set; }

        [ForeignKey("IdBarbero")]
        public required Barbero Barbero { get; set; }

        public DateTime Fecha { get; set; }

        public required string Estado { get; set; } // "Pendiente", "Confirmado", "Cancelado"
    }
}

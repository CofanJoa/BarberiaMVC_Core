using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberiaMVC_Core.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }

        [Phone]
        public required string Telefono { get; set; }
    }
}

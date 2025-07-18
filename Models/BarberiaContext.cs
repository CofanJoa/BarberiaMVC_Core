using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;


namespace BarberiaMVC_Core.Models
{
    public class BarberiaContext : DbContext
    {
        public BarberiaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Barbero> Barberos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Turno> Turnos { get; set; }
    }
}

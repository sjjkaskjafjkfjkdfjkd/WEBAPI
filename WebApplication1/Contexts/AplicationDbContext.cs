using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Contexts
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Estudiante> Estudiante { get; set;  }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Docente> Docente { get; set; }
        public DbSet<Asignacion> Asignacions { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }

        protected AplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}

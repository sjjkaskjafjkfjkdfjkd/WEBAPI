using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}

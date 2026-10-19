using Microsoft.OpenApi.MicrosoftExtensions;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set;  }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(50)]
        public string Apellidos { get; set; }
    }
}

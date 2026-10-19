using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Docente
    {
        [Key]
        public int DocenteId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(50)]
        public string Nombres {  get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(50)]
        public string Apellido { get; set; }
    }
}

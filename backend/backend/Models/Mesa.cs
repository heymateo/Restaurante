using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Mesa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Mesa { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        public bool Disponible { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        public int Id_Cliente { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [DisplayName("Activar")]
        public bool Activa { get; set; }
        public Orden Orden { get; set; } // Para navegación en el context
    }
}

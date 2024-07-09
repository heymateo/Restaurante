using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Cliente { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Apellido { get; set; }
        public IEnumerable<Orden> Ordenes { get; set; } // Para ver la lista
    }
}

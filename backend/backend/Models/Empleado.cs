using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Empleado { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato inválido")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        public bool Activo { get; set; }
        public IEnumerable<Orden> Ordenes { get; set; } 
    }
}

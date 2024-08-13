using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        [StringLength(40, ErrorMessage = "Máximo 40 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [StringLength(40, ErrorMessage = "Máximo 40 caracteres")]
        public string Apellido { get; set; }
        [BindNever]
        public ICollection<Orden> Ordenes { get; set; } // Para ver la lista
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Categoria { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Nombre { get; set; }
        [BindNever]
        public IEnumerable<Platillo> Platillos { get; set; } // Para ver la lista
        [BindNever]
        public IEnumerable<Bebida> Bebidas { get; set; } // Para ver la lista
    }
}

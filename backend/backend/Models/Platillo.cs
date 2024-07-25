using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Platillo
    {
        public int Id_Platillo { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Precio { get; set; }
        public int? Id_Categoria { get; set; }
        [BindNever]
        public Categoria Categoria { get; set; } // Para navegación en el context
        [BindNever]
        public ICollection<DetalleOrden> DetalleOrdenes { get; set; }
    }
}

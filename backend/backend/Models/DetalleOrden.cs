using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class DetalleOrden
    {
        public int Id_Detalle_Orden { get; set; }
        [BindNever]
        public int Id_Orden { get; set; }
        [ForeignKey("Id_Orden")]
        public Orden Orden { get; set; } // Para navegación en el context
        public int? Id_Platillo { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [DisplayName("Platillos")]
        public int Cantidad_Platillo { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [DisplayName("Bebidas")]
        public int Cantidad_Bebida { get; set; }
        public int? Id_Bebida { get; set; }
        [BindNever]
        [NotMapped]
        public Bebida Bebida { get; set; }
        [BindNever]
        [NotMapped]
        public Platillo Platillo { get; set; }
        [BindNever]
        public IEnumerable<Bebida> Bebidas { get; set; } // Para acceder, cambiar, saber el largo de esta lista
        [BindNever]
        public IEnumerable<Platillo> Platillos { get; set; } // Para acceder, cambiar, saber el largo de esta lista
        public decimal Precio { get; set; }
    }
}

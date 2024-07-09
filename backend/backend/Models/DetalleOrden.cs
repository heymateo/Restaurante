using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class DetalleOrden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Detalle_Orden { get; set; }
        public int Id_Orden { get; set; }
        public Orden Orden { get; set; } // Para navegación en el context
        public int Id_Platillo { get; set; }
        public Platillo Platillo { get; set; } // Para navegación en el context
        public List<Platillo> Platillos { get; set; } // Para acceder, cambiar, saber el largo de esta lista

        [Required(ErrorMessage = "Es requerido")]
        public int Cantidad_Platillo { get; set; }
        public int Id_Bebida { get; set; }
        public Bebida Bebida { get; set; } // Para navegación en el context
        public List<Bebida> Bebidas { get; set; } // Para acceder, cambiar, saber el largo de esta lista

        [Required(ErrorMessage = "Es requerido")]
        public int Cantidad_Bebida { get; set; }
        public decimal Precio { get; set; }
    }
}

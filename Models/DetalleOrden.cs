using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class DetalleOrden
    {
        public int Id_Detalle_Orden { get; set; }
        [BindNever]
        public int Id_Orden { get; set; }
        [ForeignKey("Id_Orden")]
        public Orden Orden { get; set; } // Para navegación en el context
        [Required(ErrorMessage = "Es requerido")]
        [DisplayName("Cantidad de Platillos")]
        public int Cantidad_Platillo { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [DisplayName("Cantidad de Bebidas")]
        public int Cantidad_Bebida { get; set; }
        public int? Id_Bebida { get; set; }
        public int? Id_Platillo { get; set; }
        [BindNever]
        [NotMapped]
        [JsonIgnore]
        [ForeignKey("Id_Bebida")]
        public Bebida? Bebida { get; set; }
        [BindNever]
        [NotMapped]
        [JsonIgnore]
        [ForeignKey("Id_Platillo")]
        public Platillo? Platillo { get; set; }
        [BindNever]
        [JsonIgnore]
        public IEnumerable<Bebida>? Bebidas { get; set; } // Para acceder, cambiar, saber el largo de esta lista
        [BindNever]
        [JsonIgnore]
        public IEnumerable<Platillo>? Platillos { get; set; } // Para acceder, cambiar, saber el largo de esta lista
        public int Precio { get; set; }
    }
}

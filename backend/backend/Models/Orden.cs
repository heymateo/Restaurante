using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Orden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Orden { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [DataType(DataType.Time)]
        public TimeSpan Hora { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [DisplayName("#")]
        public int Numero_Orden { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [DisplayName("Mesero")]
        public string Mesero_Atendio { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [DisplayName("Cantidad de personas")]
        public int Cantidad_Personas { get; set; }
        public bool Cancelado { get; set; }
        [ForeignKey("DetalleOrden")]
        public int Id_Detalle_Orden { get; set; }
        public DetalleOrden DetalleOrden { get; set; } // Para navegación en el context
        public ICollection<DetalleOrden> DetalleOrdenes { get; set; } // Para acceder, cambiar, saber el largo de esta colección

        [ForeignKey("Empleado")]
        public int Id_Empleado { get; set; }
        public Empleado Empleado { get; set; } // Para navegación en el context

        [ForeignKey("Cliente")]
        public int Id_Cliente { get; set; }
        public Cliente Cliente { get; set; } // Para navegación en el context

        [ForeignKey("Mesa")]
        public int Id_Mesa { get; set; }
        public Mesa Mesa { get; set; } // Para navegación en el context

        [ForeignKey("Chef")]
        public int Id_Chef { get; set; }
        public Chef Chef { get; set; } // Para navegación en el context
        [ForeignKey("Cuenta")]
        public int Id_Cuenta { get; set; }
        public Cuenta Cuenta { get; set; } // Para navegación en el context
    }
}

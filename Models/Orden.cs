using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Orden
    {
        [Key]
        public int Id_Orden { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}")]
        public TimeSpan Hora { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [DisplayName("#")]
        public int Numero_Orden { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [DisplayName("Personas")]
        public int Cantidad_Personas { get; set; }
        public bool Cancelado { get; set; }
        [BindNever]
        public int Id_Detalle_Orden { get; set; }
        [BindNever]
        public DetalleOrden DetalleOrden { get; set; }

        [BindNever]
        public int Id_Empleado { get; set; }
        [BindNever]
        [JsonIgnore]
        public Empleado Empleado { get; set; }

        [BindNever]
        public int Id_Cliente { get; set; }
        [BindNever]
        [JsonIgnore]

        public Cliente Cliente { get; set; }

        [BindNever]
        public int Id_Mesa { get; set; }
        [BindNever]
        [JsonIgnore]
        public Mesa Mesa { get; set; }

        [BindNever]
        public int Id_Chef { get; set; }
        [BindNever]
        [JsonIgnore]

        public Chef Chef { get; set; } 
        [BindNever]
        [JsonIgnore]

        public Cuenta Cuenta { get; set; } 
    }
}

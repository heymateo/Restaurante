using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace frontend.Models
{
    public class OrdenDTO
    {
        [Required(ErrorMessage = "Es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}")]
        public TimeSpan Hora { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayName("Número de Orden")]
        public int Numero_Orden { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [DisplayName("Personas")]
        public int Cantidad_Personas { get; set; }
        public bool Cancelado { get; set; }
        [BindNever]
        public int Id_Detalle_Orden { get; set; }
        [BindNever]
        public int Id_Empleado { get; set; }
        [BindNever]
        public int Id_Cliente { get; set; }
        public int Id_Mesa { get; set; }
        [BindNever]
        public int Id_Chef { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class OrdenModel
    {
        [Key]
        public int Id_Orden { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int Numero_Orden { get; set; }
        public int Cantidad_Personas { get; set; }
        public bool Cancelado { get; set; }
        public int Id_Detalle_Orden { get; set; }
        public int Id_Empleado { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Mesa { get; set; }
        public int Id_Chef { get; set; }
    }
}

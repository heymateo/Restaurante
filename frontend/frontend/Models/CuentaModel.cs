using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class CuentaModel
    {
        [Key]
        public int Id_Cuenta { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Orden { get; set; }
        public decimal Total { get; set; }
        public bool Cancelado { get; set; }
    }
}

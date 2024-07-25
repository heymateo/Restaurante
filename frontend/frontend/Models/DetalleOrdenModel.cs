using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class DetalleOrdenModel
    {
        [Key]
        public int Id_Detalle_Orden { get; set; }
        public int Id_Orden { get; set; }
        public int? Id_Platillo { get; set; }
        public int Cantidad_Platillo { get; set; }
        public int Cantidad_Bebida { get; set; }
        public int? Id_Bebida { get; set; }
        public decimal Precio { get; set; }
    }
}

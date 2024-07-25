using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class BebidaModel
    {
        [Key]
        public int Id_Bebida { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int? Id_Categoria { get; set; }
    }
}

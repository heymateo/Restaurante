using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class MesaModel
    {
        [Key]
        public int Id_Mesa { get; set; }
        public bool Disponible { get; set; }
        public int Id_Cliente { get; set; }
        public bool Activa { get; set; }
    }
}

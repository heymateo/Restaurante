using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}

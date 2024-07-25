using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class CategoriaModel
    {
        [Key]
        public int Id_Categoria { get; set; }
        public string Nombre { get; set; }
    }   
}

using backend.Models;

namespace frontend.Models
{
    public class PlatilloViewModel
    {
        public Platillo Platillo { get; set; }
        public int Id_Platillo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int? Id_Categoria { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }
    }
}

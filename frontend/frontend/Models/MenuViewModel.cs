using backend.Models;

namespace frontend.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public List<Platillo> Platillos { get; set; }
        public List<Bebida> Bebidas { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}

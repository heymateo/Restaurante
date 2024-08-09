using backend.Models;

namespace frontend.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public ICollection<Platillo> Platillos { get; set; }
        public ICollection<Bebida> Bebidas { get; set; }
    }
}

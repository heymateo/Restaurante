using backend.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace frontend.Models
{
    public class PlatilloViewModel
    {
        public int Id_Platillo { get; set; }
        public Platillo Platillo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int? Id_Categoria { get; set; }
        [BindNever]
        public List<Categoria>? Categorias { get; set; }
    }
}

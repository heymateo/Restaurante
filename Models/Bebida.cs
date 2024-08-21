using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Bebida
    {
        public int Id_Bebida { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        public int Precio { get; set; }

        public int? Id_Categoria { get; set; }

        [BindNever]
        [JsonIgnore]
        public Categoria? Categoria { get; set; }

        [BindNever]
        [JsonIgnore]
        public ICollection<DetalleOrden>? DetalleOrdenes { get; set; }

    }
}

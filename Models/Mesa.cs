using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Mesa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Mesa { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [DisplayName("Número de mesa")]
        public string Numero_Mesa { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        public bool Disponible { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [DisplayName("Activar")]
        public bool Activa { get; set; }
        [BindNever]
        [JsonIgnore]
        [NotMapped]
        public Orden? Orden { get; set; } // Para navegación en el context
    }
}

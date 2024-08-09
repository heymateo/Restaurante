using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Empleado
    {
        [Key]
        public int Id_Empleado { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [EmailAddress(ErrorMessage = "Formato inválido")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        public bool Activo { get; set; }
        [BindNever]
        [NotMapped]
        [JsonIgnore]
        public ICollection<Orden>? Ordenes { get; set; } 
    }
}

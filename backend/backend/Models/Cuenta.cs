using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Cuenta
    {
        [Display(Name = "Cuenta")]

        public int Id_Cuenta { get; set; }
        [ForeignKey("Cliente")]
        [Display(Name = "Cliente")]

        public int Id_Cliente { get; set; }
        [ForeignKey("Orden")]
        public int Id_Orden { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Total { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        public bool Cancelado { get; set; }
        [BindNever]
        public Orden Orden { get; set; } 
    }
}

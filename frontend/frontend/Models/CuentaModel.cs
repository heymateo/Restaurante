using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class CuentaModel
    {
        [Key]
        [Display(Name = "Cuenta")]

        public int Id_Cuenta { get; set; }
        [Display(Name = "Cliente")]

        
        public int Id_Cliente { get; set; }
        [Display(Name = "Orden")]

        public int Id_Orden { get; set; }
        [Display(Name = "Total")]

        public decimal Total { get; set; }
        [Display(Name = "Cancelado")]

        public bool Cancelado { get; set; }
        
    }
}

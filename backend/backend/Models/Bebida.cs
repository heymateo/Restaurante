using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Bebida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Bebida { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }
        [ForeignKey("Categoria")]
        public int Id_Categoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}

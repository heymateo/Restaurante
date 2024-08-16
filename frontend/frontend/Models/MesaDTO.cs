using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class MesaDTO
    {
        public int Id_Mesa { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        [DisplayName("Número de mesa")]
        public string Numero_Mesa { get; set; }
        [Required(ErrorMessage = "Es requerido")]
        public bool Disponible { get; set; }
        [DisplayName("Activar")]
        public bool Activa { get; set; }
    }
}

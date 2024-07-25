using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class AdministradorModel
    {
        [Key]
        public int Id_Administrador { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public bool Activo { get; set; }
    }
}

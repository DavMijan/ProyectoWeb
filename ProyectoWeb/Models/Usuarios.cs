using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWeb.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        [Display(Name = "Correo")]
        public string CorreoUsuario { get; set; }

        [Display(Name = "Contraseña")]
        public string ContraseñaUsuario { get; set; }

        [Display(Name = "Nombre")]
        public string NombreUsuario { get; set; }

        [Display(Name = "Tipo de Usuario")]
        //[ForeignKey("TiposUsuarios")]
        public int IdTipoUsuario { get; set; }

        [Display(Name = "Estado")]
        public int EstadoUsuario { get; set; }

        //public TiposUsuarios TiposUsuarios { get; set; }


    }


}

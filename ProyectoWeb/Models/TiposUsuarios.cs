using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models
{
    public class TiposUsuarios
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Usuario")]
        public string TipoUsuario { get; set; }

        [Display(Name = "Estado")]
        public int EstadoUsuario { get; set; }

        //public ICollection<Empleados> Empleados { get; set; }
    }
}

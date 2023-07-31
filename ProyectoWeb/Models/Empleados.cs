using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models
{
    public class Empleados
    {
        public int Id { get; set; }

        [Display(Name = "DPI")]
        public int DpiEmpleado { get; set; }

        [Display(Name = "Nombre")]
        public string NombreEmpleado { get; set; }

        [Display(Name = "Apellido")]
        public string ApellidoEmpleado { get; set; }

        [Display(Name = "Teléfono")]
        public int TelefonoEmpleado { get; set; }

        [Display(Name = "Dirección")]
        public string DireccionEmpleado { get; set; }

        [Display(Name = "Área")]
        public string AreaEmpleado { get; set; }

        [Display(Name = "Estado")]
        public int EstadoEmpleado { get; set; }

    }
}

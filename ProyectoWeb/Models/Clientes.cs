using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWeb.Models
{
    public class Clientes
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string NombreCliente { get; set; }

        [Display(Name = "Correo")]
        public string CorreoCliente { get; set; }

        [Display(Name = "Dirección")]
        public string DireccionCliente { get; set; }

        [Display(Name = "Teléfono")]
        public int TelefonoCliente { get; set; }

        [Display(Name = "Tipo de Cliente")]
        //[ForeignKey ("TiposClientes")]
        public int IdTipoCliente { get; set; }
        //public TiposClientes TiposClientes { get; set; }

        [Display(Name = "Estado")]
        public int EstadoCliente { get; set; }

    }
}

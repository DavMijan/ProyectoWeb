using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models
{
    public class TiposClientes
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Cliente")]
        public string TipoCliente { get; set; }

        [Display(Name = "Estado")]
        public int EstadoTipoCliente { get; set; }

        //public ICollection<Clientes> Clientess { get; set; }

    }
}

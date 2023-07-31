using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWeb.Models
{
    public class Medidores
    {
        public int Id { get; set; }

        [Display(Name = "NIS")]
        public int Nis { get; set; }

        [Display(Name = "Cliente")]
        //[ForeignKey("Clientes")]
        public int IdCliente { get; set; }

        [Display(Name = "Tipo de Medidor")]
        //[ForeignKey("TiposMedidores")]
        public int IdTipoMedidor { get; set; }

        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; }

        [Display(Name = "Estado")]
        public int EstadoMedidor { get; set; }

        //public Clientes Clientes { get; set; }

        //public TiposMedidores TiposMedidores { get; set; }

        //public ICollection<Alertas> Alertas { get; set; }
    }
}

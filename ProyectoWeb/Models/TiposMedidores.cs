using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models
{
    public class TiposMedidores
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Medidor")]
        public string TipoMedidor { get; set; }

        [Display(Name = "Estado")]
        public int EstadoTipoMedidor { get; set; }

        //public ICollection<Medidores> Medidores { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWeb.Models
{
    public class Alertas
    {
        public int Id { get; set; }

        //[ForeignKey("Medidores")]
        [Display(Name = "Medidor")]
        public int IdMedidor { get; set; }

        [Display(Name = "Alerta")]
        public string Alerta { get; set; }

        [Display(Name = "Estado")]
        public int EstadoAlerta { get; set; }

        //public Medidores Medidores { get; set; }
    }
}

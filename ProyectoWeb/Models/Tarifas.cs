using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWeb.Models
{
    public class Tarifas
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Tarifa")]
        public string TipoTarifa { get; set; }

        [Display(Name = "Monto")]
        public float Monto { get; set; }

        //public ICollection<Detalles> Detalles { get; set; }
    }
}

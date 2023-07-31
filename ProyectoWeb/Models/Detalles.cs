using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWeb.Models
{
    public class Detalles
    {
        public int Id { get; set; }

        [Display(Name = "Encabezado")]
        //[ForeignKey("Encabezados")]
        public int IdEncabezado { get; set; }

        [Display(Name = "Lectura")]
        //[ForeignKey("Lecturas")]
        public int IdLectura { get; set; }

        //[ForeignKey("Tarifas")]
        [Display(Name = "Tarifa")]
        public int IdTarifa { get; set; }

        [Display(Name = "Consumo")]
        public float Consumo { get; set; }

        [Display(Name = "Subtotal")]
        public float Subtotal { get; set; }

        [Display(Name = "Facturas Pendientes")]
        public float FacturasPendientes { get; set; }

        [Display(Name = "Total")]
        public float Total { get; set; }

        [Display(Name = "Estado")]
        public int EstadoDetalle { get; set; }

        //public Encabezados Encabezados { get; set; }

        //public Lecturas Lecturas { get; set; }

        //public Tarifas Tarifas { get; set; }
    }
}

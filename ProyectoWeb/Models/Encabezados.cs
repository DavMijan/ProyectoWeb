using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWeb.Models
{
    public class Encabezados
    {
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        public DateTime FechaEncabezado { get; set; }

        [Display(Name = "Medidor")]
        //[ForeignKey("Medidores")]
        public int IdMedidor { get; set; }

        [Display(Name = "Fecha")]
        //[ForeignKey("DimTiempo")]
        public int FechaID { get; set; }

        [Display(Name = "Estado")]
        public int EstadoEncabezado { get; set; }

        //public Medidores Medidores { get; set; }

        //public DimTiempo DimTiempo { get; set; }
    }
}

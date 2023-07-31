using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWeb.Models
{
    public class Lecturas
    {
        public int Id { get; set; }

        [Display(Name = "Medidor")]
        //[ForeignKey("Medidores")]
        public int IdMedidor { get; set; }

        [Display(Name = "Fecha")]
        //[ForeignKey("DimTiempo")]
        public int FechaID { get; set; }

        [Display(Name = "Empleado")]
        //[ForeignKey("Empleados")]
        public int IdEmpleado { get; set; }

        [Display(Name = "Lectura")]
        public string Lectura { get; set; }

        [Display(Name = "Estado")]
        public int EstadoLectura { get; set; }


        //public ICollection<Detalles> Detalles { get; set; }
        //public Medidores Medidores { get; set; }

        //public DimTiempo DimTiempo { get; set; }

        //public Empleados Empleados { get; set; }
    }
}

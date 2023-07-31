using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models
{
    public class DimTiempo
    {
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Año")]
        public int Anio { get; set; }

        [Display(Name = "Mes")]
        public int Mes { get; set; }

        [Display(Name = "Día")]
        public int Dia { get; set; }

        [Display(Name = "Nombre del Mes")]
        public string NombreMes { get; set; }

        [Display(Name = "Nombre del Día")]
        public string NombreDia { get; set; }

        //public ICollection<Lecturas> Lecturas { get; set; }

        //public ICollection<Encabezados> Encabezados { get; set; }
    }
}


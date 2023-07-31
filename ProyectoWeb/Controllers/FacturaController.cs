using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb.Data;
using ProyectoWeb.Models;


namespace ProyectoWeb.Controllers
{
    [Authorize(Roles = "2")]
    public class FacturaController : Controller
    {
        private readonly ProyectoWebContext _context;

        public FacturaController(ProyectoWebContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerarFactura(int nis, float consumoActual)
        {
            // Verificar si el medidor con el NIS proporcionado existe en la tabla de Medidores
            var medidor = _context.Medidores.FirstOrDefault(m => m.Nis == nis);
            if (medidor == null)
            {
                ViewBag.ErrorMessage = "El NIS proporcionado no existe.";
                return View("Index");
            }

            // Obtener la última lectura del medidor
            var ultimaLectura = _context.Lecturas
                .Where(l => l.IdMedidor == medidor.Id)
                .OrderByDescending(l => l.FechaID)
                .FirstOrDefault();

            if (ultimaLectura == null)
            {
                // Obtener la fecha actual
                DateTime fechaGeneracion = DateTime.Now;

                // Verificar si existe una entrada en DimTiempo con la fechaGeneracion
                var dimTiempo = _context.DimTiempo.FirstOrDefault(dt => dt.Fecha.Date == fechaGeneracion.Date);

                // Si no existe, generar una nueva instancia de DimTiempo con la fechaGeneracion
                if (dimTiempo == null)
                {
                    dimTiempo = new DimTiempo
                    {
                        Fecha = fechaGeneracion,
                        Anio = fechaGeneracion.Year,
                        Mes = fechaGeneracion.Month,
                        Dia = fechaGeneracion.Day,
                        NombreMes = fechaGeneracion.ToString("MMMM"),
                        NombreDia = fechaGeneracion.ToString("dddd")
                    };

                    // Agregar la nueva instancia de DimTiempo a la base de datos
                    _context.DimTiempo.Add(dimTiempo);
                    _context.SaveChanges();
                }

                // Crear una nueva instancia de la entidad "Lectura" con los datos proporcionados
                var nuevaLectura = new Lecturas
                {
                    IdMedidor = medidor.Id,
                    FechaID = dimTiempo.Id,
                    IdEmpleado = 1,
                    Lectura = "0",
                    EstadoLectura = 1
                };

                // Agregar la nueva lectura a la base de datos
                _context.Lecturas.Add(nuevaLectura);
                _context.SaveChanges();

                // Establecer la última lectura como la lectura recién creada
                ultimaLectura = nuevaLectura;
            }

            // Calcular el consumo actual restando la última lectura al consumo actual
            float consumoAnterior = float.Parse(ultimaLectura.Lectura);
            float consumoCalculado = consumoActual - consumoAnterior;
            float PrecioTotal = (float)(consumoCalculado * 1.12);

            // Pasar los datos a la vista utilizando ViewBag
            ViewBag.Cliente = _context.Clientes.FirstOrDefault(c => c.Id == medidor.IdCliente);
            ViewBag.Medidor = medidor;
            ViewBag.ConsumoActual = consumoActual;
            ViewBag.ConsumoAnterior = consumoAnterior;
            ViewBag.ConsumoCalculado = consumoCalculado;
            ViewBag.PrecioTotal = PrecioTotal;

            return View("Factura");
        }

        [HttpPost]
        public IActionResult GenerarLectura(int idMedidor, string lecturaCalculada, DateTime fechaGeneracion, string filePath)
        {
            // Verificar si existe una entrada en DimTiempo con la fechaGeneracion
            var dimTiempo = _context.DimTiempo.FirstOrDefault(dt => dt.Fecha.Date == fechaGeneracion.Date);

            // Si no existe, generar una nueva instancia de DimTiempo con la fechaGeneracion
            if (dimTiempo == null)
            {
                dimTiempo = new DimTiempo
                {
                    Fecha = fechaGeneracion,
                    Anio = fechaGeneracion.Year,
                    Mes = fechaGeneracion.Month,
                    Dia = fechaGeneracion.Day,
                    NombreMes = fechaGeneracion.ToString("MMMM"),
                    NombreDia = fechaGeneracion.ToString("dddd")
                };

                // Agregar la nueva instancia de DimTiempo a la base de datos
                _context.DimTiempo.Add(dimTiempo);
                _context.SaveChanges();
            }

            // Crear una nueva instancia de la entidad "Lectura"
            var nuevaLectura = new Lecturas
            {
                IdMedidor = idMedidor,
                FechaID = dimTiempo.Id,
                IdEmpleado = 1, // Id del empleado que genera la lectura (aquí asumimos que es 1)
                Lectura = lecturaCalculada,
                EstadoLectura = 0 // Estado de la lectura (aquí asumimos que es 0)

            };

            // Agregar la nueva lectura a la base de datos
            _context.Lecturas.Add(nuevaLectura);
            _context.SaveChanges();


            return RedirectToAction("Index", "Factura");
        }

    }
}

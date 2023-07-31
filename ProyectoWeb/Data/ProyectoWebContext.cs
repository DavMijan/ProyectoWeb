using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb.Models;

namespace ProyectoWeb.Data
{
    public class ProyectoWebContext : DbContext
    {
        public ProyectoWebContext (DbContextOptions<ProyectoWebContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoWeb.Models.Alertas> Alertas { get; set; } = default!;

        public DbSet<ProyectoWeb.Models.Clientes> Clientes { get; set; } = default!;

        public DbSet<ProyectoWeb.Models.Detalles> Detalles { get; set; } = default!;

        public DbSet<ProyectoWeb.Models.DimTiempo> DimTiempo { get; set; } = default!;

        public DbSet<ProyectoWeb.Models.Empleados> Empleados { get; set; } = default!;

        public DbSet<ProyectoWeb.Models.Encabezados> Encabezados { get; set; } = default!;

        public DbSet<ProyectoWeb.Models.Lecturas> Lecturas { get; set; } = default!;

        public DbSet<ProyectoWeb.Models.Medidores> Medidores { get; set; } = default!;

        public DbSet<ProyectoWeb.Models.Tarifas> Tarifas { get; set; } = default!;

        public DbSet<ProyectoWeb.Models.TiposClientes> TiposClientes { get; set; } = default!;

        public DbSet<ProyectoWeb.Models.TiposMedidores> TiposMedidores { get; set; } = default!;

        public DbSet<ProyectoWeb.Models.TiposUsuarios> TiposUsuarios { get; set; } = default!;

        public DbSet<ProyectoWeb.Models.Usuarios> Usuarios { get; set; } = default!;
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProyectoWeb.Data;
using System;
using System.Linq;

namespace ProyectoWeb.Models;
    public static class SeedData
    {
    
        public static void Initialize(IServiceProvider serviceProvider)
        {
        using (var context = new ProyectoWebContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<ProyectoWebContext>>()))
        {
                // Look for any records in the tables.
                if (context.TiposClientes.Any() ||
                    context.Clientes.Any() ||
                    context.TiposMedidores.Any() ||
                    context.Medidores.Any() ||
                    context.Alertas.Any() ||
                    context.TiposUsuarios.Any() ||
                    context.Empleados.Any() ||
                    context.Usuarios.Any() ||
                    context.DimTiempo.Any() ||
                    context.Lecturas.Any() ||
                    context.Encabezados.Any() ||
                    context.Tarifas.Any() ||
                    context.Detalles.Any())
                {
                    return;   // DB has been seeded
                }

                // Seed data for TiposClientes table
                context.TiposClientes.AddRange(
                    new TiposClientes { TipoCliente = "Individual", EstadoTipoCliente = 1 },
                    new TiposClientes { TipoCliente = "Negocio", EstadoTipoCliente = 1 },
                    new TiposClientes { TipoCliente = "Empresa", EstadoTipoCliente = 1 }
                );

                // Seed data for Clientes table
                context.Clientes.AddRange(
                    new Clientes { NombreCliente = "Cliente 1", CorreoCliente = "cliente1@example.com", DireccionCliente = "Dirección 1", TelefonoCliente = 123456789, IdTipoCliente = 1, EstadoCliente = 1 },
                    new Clientes { NombreCliente = "Cliente 2", CorreoCliente = "cliente2@example.com", DireccionCliente = "Dirección 2", TelefonoCliente = 987654321, IdTipoCliente = 2, EstadoCliente = 1 },
                    new Clientes { NombreCliente = "Cliente 3", CorreoCliente = "cliente3@example.com", DireccionCliente = "Dirección 3", TelefonoCliente = 555555555, IdTipoCliente = 3, EstadoCliente = 1 }
                );

                // Seed data for TiposMedidores table
                context.TiposMedidores.AddRange(
                    new TiposMedidores { TipoMedidor = "Estandar", EstadoTipoMedidor = 1 },
                    new TiposMedidores { TipoMedidor = "Bidireccional", EstadoTipoMedidor = 1 },
                    new TiposMedidores { TipoMedidor = "Empresa", EstadoTipoMedidor = 1 }
                );

                // Seed data for Medidores table
                context.Medidores.AddRange(
                    new Medidores { Nis = 12345678, IdCliente = 1, IdTipoMedidor = 1, Ubicacion = "Rabinal, Baja Verapaz", EstadoMedidor = 1 },
                    new Medidores { Nis = 87654321, IdCliente = 2, IdTipoMedidor = 2, Ubicacion = "Salama, Baja Verapaz", EstadoMedidor = 1 },
                    new Medidores { Nis = 11111111, IdCliente = 3, IdTipoMedidor = 3, Ubicacion = "Cubulco, Baja Verapaz", EstadoMedidor = 1 }
                );

                // Seed data for Alertas table
                context.Alertas.AddRange(
                    new Alertas { IdMedidor = 1, Alerta = "Prueba Alarma", EstadoAlerta = 1 },
                    new Alertas { IdMedidor = 2, Alerta = "Prueba Alarm", EstadoAlerta = 1 },
                    new Alertas { IdMedidor = 3, Alerta = "Prueba Alarm", EstadoAlerta = 1 }
                );

                // Seed data for TiposUsuarios table
                context.TiposUsuarios.AddRange(
                    new TiposUsuarios { TipoUsuario = "Administrador", EstadoUsuario = 1 },
                    new TiposUsuarios { TipoUsuario = "Empleado", EstadoUsuario = 1 },
                    new TiposUsuarios { TipoUsuario = "Usuario", EstadoUsuario = 1 }
                );

                // Seed data for Empleados table
                context.Empleados.AddRange(
                    new Empleados { DpiEmpleado = 123456789, NombreEmpleado = "Elman ", ApellidoEmpleado = "Morales", TelefonoEmpleado = 111111111, DireccionEmpleado = "Rabinal, Baja Verapaz", AreaEmpleado = "Área 1", EstadoEmpleado = 1 },
                    new Empleados { DpiEmpleado = 987654321, NombreEmpleado = "Emerson ", ApellidoEmpleado = "Perez", TelefonoEmpleado = 222222222, DireccionEmpleado = "Rabinal, Baja Verapaz", AreaEmpleado = "Área 2", EstadoEmpleado = 1 },
                    new Empleados { DpiEmpleado = 555555555, NombreEmpleado = "Ever ", ApellidoEmpleado = "Geovany", TelefonoEmpleado = 333333333, DireccionEmpleado = "Rabinal, Baja Verapaz", AreaEmpleado = "Área 3", EstadoEmpleado = 1 }
                );

                // Seed data for Usuarios table
                context.Usuarios.AddRange(
                    new Usuarios { CorreoUsuario = "admin@gmail.com", ContraseñaUsuario = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220f8\r\n", NombreUsuario = "Administrador",  IdTipoUsuario = 1, EstadoUsuario = 1 },
                    new Usuarios { CorreoUsuario = "emp@gmail.com", ContraseñaUsuario = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220f8\r\n", NombreUsuario = "Empleado",  IdTipoUsuario = 2, EstadoUsuario = 1 },
                    new Usuarios { CorreoUsuario = "user@gmail.com", ContraseñaUsuario = "7110eda4d09e062aa5e4a390b0a572ac0d2c0220f8\r\n", NombreUsuario = "Usuario",  IdTipoUsuario = 3, EstadoUsuario = 1 }
                );

                // Save changes to the database
                context.SaveChanges();
            }
    
        }
    
}


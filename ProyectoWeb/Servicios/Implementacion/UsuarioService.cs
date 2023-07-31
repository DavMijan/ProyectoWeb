using Microsoft.EntityFrameworkCore;
using ProyectoWeb.Data;
using ProyectoWeb.Models;
using ProyectoWeb.Servicios.Contrato;

namespace ProyectoWeb.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ProyectoWebContext _context;

        public UsuarioService(ProyectoWebContext context)
        {
            _context = context;
        }
        public async Task<Usuarios> GetUsuarios(string correoUsuario, string contraseñaUsuario)
        {
            Usuarios usuario_encontrado = await _context.Usuarios.Where(u => u.CorreoUsuario == correoUsuario && u.ContraseñaUsuario == contraseñaUsuario)
            .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuarios> SaveUsuario(Usuarios modelo)
        {
            _context.Usuarios.Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }
    }
}

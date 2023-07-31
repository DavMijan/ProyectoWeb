using ProyectoWeb.Models;

namespace ProyectoWeb.Servicios.Contrato

{
    public interface IUsuarioService
    {
        Task<Usuarios> GetUsuarios(string correoUsuario, string contraseñaUsuario);
        Task<Usuarios> SaveUsuario(Usuarios modelo);


    }
}

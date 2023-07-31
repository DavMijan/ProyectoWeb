using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;
using ProyectoWeb.Recursos;
using System.Security.Claims;
using ProyectoWeb.Data;
using ProyectoWeb.Servicios.Contrato;
using System.Diagnostics;

namespace ProyectoWeb.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;
        public InicioController(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        private readonly ProyectoWebContext _context;

        public IActionResult Registrarse()
        {
            return View();
        }
        
        [HttpPost]

        public async Task<IActionResult> Registrarse(Usuarios modelo)
        {
                modelo.EstadoUsuario = 1; // Establecer el valor predeterminado para EstadoUsuario
                modelo.IdTipoUsuario = 3;
                modelo.ContraseñaUsuario = Utilidades.EncriptarClave(modelo.ContraseñaUsuario);

                Usuarios usuario_creado = await _usuarioServicio.SaveUsuario(modelo);

                if (usuario_creado.Id > 0)
                    return RedirectToAction("Index", "Home");

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }
        
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correoUsuario, string ContraseñaUsuario)
        {

            Usuarios usuario_encontrado = await _usuarioServicio.GetUsuarios(correoUsuario, Utilidades.EncriptarClave(ContraseñaUsuario));

            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";
                Debug.WriteLine("Mensaje generado: No se encontraron coincidencias");
                return View();
            }
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, usuario_encontrado.NombreUsuario),
                new Claim(ClaimTypes.Role, usuario_encontrado.IdTipoUsuario.ToString())
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Index", "Home");
        }
    }
}

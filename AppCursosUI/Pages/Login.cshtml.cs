using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCursosUI.DTOs;
using AppCursosUI.Gateways.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AppCursosUI.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly IManejadorIdentidad _identidadProvider;

        [BindProperty]
        public PeticionInicioSesion peticionInicioSesion {get; set;}

        public LoginModel(ILogger<LoginModel> logger, 
                          IManejadorIdentidad identidadProvider)
        {
            _logger = logger;
            _identidadProvider = identidadProvider;
        }

        public void OnGet()
        {
            
        }

        public void OnPost() {
            if (peticionInicioSesion != null) {
                var respuestaValidacion = _identidadProvider.ValidarUsuario(peticionInicioSesion);
                if (respuestaValidacion.correcto) {
                    HttpContext.Session.SetString("token_usuario", "token");
                    Response.Redirect("/");
                }
            }
        }
    }
}
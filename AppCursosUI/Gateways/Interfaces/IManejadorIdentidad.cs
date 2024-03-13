using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCursosUI.DTOs;

namespace AppCursosUI.Gateways.Interfaces
{
    public interface IManejadorIdentidad
    {        
        public RespuestaValidacionUsuario ValidarUsuario(PeticionInicioSesion peticionInicioSesion);
    }
}
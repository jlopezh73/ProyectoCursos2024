using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCursosUIBlazor.DTOs;

namespace AppCursosUIBlazor.Gateways.Interfaces
{
    public interface IManejadorIdentidad
    {        
        public RespuestaValidacionUsuario ValidarUsuario(PeticionInicioSesion peticionInicioSesion);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCursosUI.DTOs
{
    public class RespuestaValidacionUsuario
    {
        public bool correcto {get; set;}
        public Usuario? usuario {get; set;}
    }
}
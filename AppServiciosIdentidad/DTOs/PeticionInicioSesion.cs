using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServiciosIdentidad.DTOs
{
    public class PeticionInicioSesion
    {
        public String correoElectronico {get; set;}
        public String password {get; set;}
        public String recordarme {get; set;}
    }
}
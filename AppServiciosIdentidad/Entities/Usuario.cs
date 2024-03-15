using System;
using System.Collections.Generic;

namespace AppServiciosIdentidad.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Paterno { get; set; }

    public string? Materno { get; set; }

    public string? Nombre { get; set; }

    public string? Puesto { get; set; }
}

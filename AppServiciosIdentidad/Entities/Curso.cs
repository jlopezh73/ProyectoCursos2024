using System;
using System.Collections.Generic;

namespace AppServiciosIdentidad.Entities;

public partial class Curso
{
    public int Id { get; set; }

    public string? Clave { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? NoHoras { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaTermino { get; set; }

    public decimal? Costo { get; set; }

    public string? Instructor { get; set; }

    public virtual ICollection<ParticipantePago> ParticipantePagos { get; set; } = new List<ParticipantePago>();

    public virtual ICollection<Participante> Participantes { get; set; } = new List<Participante>();
}

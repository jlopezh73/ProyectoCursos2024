using System;
using System.Collections.Generic;

namespace AppServiciosIdentidad.Entities;

public partial class Participante
{
    public int Id { get; set; }

    public int? Idcurso { get; set; }

    public string? Paterno { get; set; }

    public string? Materno { get; set; }

    public string? Nombre { get; set; }

    public string? Matricula { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Pagado { get; set; }

    public virtual Curso? IdcursoNavigation { get; set; }

    public virtual ICollection<ParticipantePago> ParticipantePagos { get; set; } = new List<ParticipantePago>();
}

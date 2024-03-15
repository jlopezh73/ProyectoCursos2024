using System;
using System.Collections.Generic;

namespace AppServiciosIdentidad.Entities;

public partial class ParticipantePago
{
    public int Id { get; set; }

    public int? Idparticipante { get; set; }

    public int? Idcurso { get; set; }

    public decimal? Monto { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Curso? IdcursoNavigation { get; set; }

    public virtual Participante? IdparticipanteNavigation { get; set; }
}

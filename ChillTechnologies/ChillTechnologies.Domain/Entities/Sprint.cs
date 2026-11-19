using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Sprint
{
    public int Id { get; set; }

    public int ProyectoId { get; set; }

    public int Numero { get; set; }

    public string? Objetivo { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int PuntosComprometidos { get; set; }

    public int PuntosCompletados { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<HistoriasUsuario> HistoriasUsuarios { get; set; } = new List<HistoriasUsuario>();

    public virtual Proyecto Proyecto { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class SolicitudesAusencium
{
    public int Id { get; set; }

    public int EmpleadoId { get; set; }

    public int TipoAusenciaId { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int Dias { get; set; }

    public string? Motivo { get; set; }

    public string Estado { get; set; } = null!;

    public int? AprobadoPor { get; set; }

    public DateTime? FechaRespuesta { get; set; }

    public DateTime FechaSolicitud { get; set; }

    public virtual Empleado? AprobadoPorNavigation { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual TiposAusencium TipoAusencia { get; set; } = null!;
}

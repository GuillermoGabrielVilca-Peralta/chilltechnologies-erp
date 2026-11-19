using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Defecto
{
    public int Id { get; set; }

    public int ProyectoId { get; set; }

    public int? HistoriaId { get; set; }

    public int? VersionId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? PasosReproduccion { get; set; }

    public string Severidad { get; set; } = null!;

    public int? ReportadoPorId { get; set; }

    public int? AsignadoAId { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaReporte { get; set; }

    public DateTime? FechaCierre { get; set; }

    public virtual Empleado? AsignadoA { get; set; }

    public virtual HistoriasUsuario? Historia { get; set; }

    public virtual Proyecto Proyecto { get; set; } = null!;

    public virtual Empleado? ReportadoPor { get; set; }

    public virtual ICollection<TicketsSoporte> TicketsSoportes { get; set; } = new List<TicketsSoporte>();

    public virtual VersionesProducto? Version { get; set; }
}

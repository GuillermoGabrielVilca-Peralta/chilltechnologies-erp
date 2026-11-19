using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Despliegue
{
    public int Id { get; set; }

    public int VersionId { get; set; }

    public int AmbienteId { get; set; }

    public int? ResponsableId { get; set; }

    public DateTime FechaDespliegue { get; set; }

    public string Estado { get; set; } = null!;

    public string? Observaciones { get; set; }

    public virtual Ambiente Ambiente { get; set; } = null!;

    public virtual Empleado? Responsable { get; set; }

    public virtual VersionesProducto Version { get; set; } = null!;
}

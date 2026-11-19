using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class EjecucionesPrueba
{
    public int Id { get; set; }

    public int CasoPruebaId { get; set; }

    public int? VersionId { get; set; }

    public int? EmpleadoId { get; set; }

    public string Resultado { get; set; } = null!;

    public string? Observaciones { get; set; }

    public DateTime FechaEjecucion { get; set; }

    public virtual CasosPrueba CasoPrueba { get; set; } = null!;

    public virtual Empleado? Empleado { get; set; }

    public virtual VersionesProducto? Version { get; set; }
}

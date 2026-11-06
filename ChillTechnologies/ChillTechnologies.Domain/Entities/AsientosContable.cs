using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class AsientosContable
{
    public int Id { get; set; }

    public string Numero { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public string Glosa { get; set; } = null!;

    public string TipoAsiento { get; set; } = null!;

    public decimal TotalDebe { get; set; }

    public decimal TotalHaber { get; set; }

    public string Estado { get; set; } = null!;

    public int? EmpleadoId { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<DetalleAsiento> DetalleAsientos { get; set; } = new List<DetalleAsiento>();

    public virtual Empleado? Empleado { get; set; }
}

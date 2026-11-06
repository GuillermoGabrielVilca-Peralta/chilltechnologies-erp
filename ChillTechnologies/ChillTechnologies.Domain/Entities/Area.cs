using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Area
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    /// <summary>
    /// Jerarquia del organigrama; NULL = area raiz
    /// </summary>
    public int? AreaPadreId { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual Area? AreaPadre { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Area> InverseAreaPadre { get; set; } = new List<Area>();
}

using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class VersionesProducto
{
    public int Id { get; set; }

    public int ProductoSoftwareId { get; set; }

    public string Numero { get; set; } = null!;

    public string? NotasVersion { get; set; }

    public DateOnly? FechaLiberacion { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Defecto> Defectos { get; set; } = new List<Defecto>();

    public virtual ICollection<Despliegue> Despliegues { get; set; } = new List<Despliegue>();

    public virtual ICollection<EjecucionesPrueba> EjecucionesPruebas { get; set; } = new List<EjecucionesPrueba>();

    public virtual ProductosSoftware ProductoSoftware { get; set; } = null!;
}

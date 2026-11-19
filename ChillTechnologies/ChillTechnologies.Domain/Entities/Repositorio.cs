using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Repositorio
{
    public int Id { get; set; }

    public int? ProductoSoftwareId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Proveedor { get; set; } = null!;

    public string RamaPrincipal { get; set; } = null!;

    public string Visibilidad { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ProductosSoftware? ProductoSoftware { get; set; }
}

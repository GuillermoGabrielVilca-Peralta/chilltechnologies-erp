using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class ZonasRiesgo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Latitud { get; set; }

    public decimal Longitud { get; set; }

    public int RadioMetros { get; set; }

    public string Tipo { get; set; } = null!;

    public string NivelRiesgo { get; set; } = null!;

    public int IncidentesRegistrados { get; set; }

    public DateTime FechaRegistro { get; set; }
}

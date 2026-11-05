using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class DocumentosVehiculo
{
    public int Id { get; set; }

    public int VehiculoId { get; set; }

    public int TipoDocumentoId { get; set; }

    public string? Numero { get; set; }

    public DateOnly? FechaEmision { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    public string? Archivo { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual TiposDocumento TipoDocumento { get; set; } = null!;

    public virtual Vehiculo Vehiculo { get; set; } = null!;
}

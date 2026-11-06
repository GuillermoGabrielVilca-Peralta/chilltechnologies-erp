using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class MovimientosCaja
{
    public int Id { get; set; }

    public int CajaId { get; set; }

    public string Tipo { get; set; } = null!;

    public string Concepto { get; set; } = null!;

    public decimal Monto { get; set; }

    public string? DocumentoReferencia { get; set; }

    public int? EmpleadoId { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public virtual Caja Caja { get; set; } = null!;

    public virtual Empleado? Empleado { get; set; }
}

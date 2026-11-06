using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class CuentasPorCobrar
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int? FacturaId { get; set; }

    public DateOnly FechaEmision { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    public decimal Monto { get; set; }

    public decimal Saldo { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Factura? Factura { get; set; }
}

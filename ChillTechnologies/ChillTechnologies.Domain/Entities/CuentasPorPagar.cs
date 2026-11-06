using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class CuentasPorPagar
{
    public int Id { get; set; }

    public int ProveedorId { get; set; }

    public int? OrdenCompraId { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public DateOnly FechaEmision { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    public decimal Monto { get; set; }

    public decimal Saldo { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual OrdenesCompra? OrdenCompra { get; set; }

    public virtual Proveedore Proveedor { get; set; } = null!;
}

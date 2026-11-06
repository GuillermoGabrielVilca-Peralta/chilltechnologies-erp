using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class OrdenesCompra
{
    public int Id { get; set; }

    public int ProveedorId { get; set; }

    public string Numero { get; set; } = null!;

    public DateOnly FechaEmision { get; set; }

    public DateOnly? FechaEntregaEstimada { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Igv { get; set; }

    public decimal Total { get; set; }

    public string Estado { get; set; } = null!;

    public int? EmpleadoId { get; set; }

    public string? Observaciones { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<CuentasPorPagar> CuentasPorPagars { get; set; } = new List<CuentasPorPagar>();

    public virtual ICollection<DetalleOrdenCompra> DetalleOrdenCompras { get; set; } = new List<DetalleOrdenCompra>();

    public virtual Empleado? Empleado { get; set; }

    public virtual Proveedore Proveedor { get; set; } = null!;

    public virtual ICollection<Recepcione> Recepciones { get; set; } = new List<Recepcione>();
}

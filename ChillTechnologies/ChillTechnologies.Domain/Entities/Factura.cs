using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Factura
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int? PedidoId { get; set; }

    public string Serie { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string TipoComprobante { get; set; } = null!;

    public DateOnly FechaEmision { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Igv { get; set; }

    public decimal Total { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<CuentasPorCobrar> CuentasPorCobrars { get; set; } = new List<CuentasPorCobrar>();

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Pedido? Pedido { get; set; }
}

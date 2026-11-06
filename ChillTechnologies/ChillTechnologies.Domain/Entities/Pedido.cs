using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Pedido
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int? CotizacionId { get; set; }

    public string Numero { get; set; } = null!;

    public DateOnly FechaPedido { get; set; }

    public DateOnly? FechaEntrega { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Igv { get; set; }

    public decimal Total { get; set; }

    public string Estado { get; set; } = null!;

    public int? EmpleadoId { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Cotizacione? Cotizacion { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Empleado? Empleado { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}

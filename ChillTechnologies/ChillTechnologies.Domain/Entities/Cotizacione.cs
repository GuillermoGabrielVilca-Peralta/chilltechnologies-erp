using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Cotizacione
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public string Numero { get; set; } = null!;

    public DateOnly FechaEmision { get; set; }

    public DateOnly? FechaValidez { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Igv { get; set; }

    public decimal Total { get; set; }

    public string Estado { get; set; } = null!;

    public int? EmpleadoId { get; set; }

    public string? Observaciones { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<DetalleCotizacion> DetalleCotizacions { get; set; } = new List<DetalleCotizacion>();

    public virtual Empleado? Empleado { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}

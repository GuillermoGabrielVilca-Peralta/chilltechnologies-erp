using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class DetalleCotizacion
{
    public int Id { get; set; }

    public int CotizacionId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Cotizacione Cotizacion { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}

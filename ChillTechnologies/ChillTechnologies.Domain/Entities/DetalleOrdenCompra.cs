using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class DetalleOrdenCompra
{
    public int Id { get; set; }

    public int OrdenCompraId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public virtual OrdenesCompra OrdenCompra { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}

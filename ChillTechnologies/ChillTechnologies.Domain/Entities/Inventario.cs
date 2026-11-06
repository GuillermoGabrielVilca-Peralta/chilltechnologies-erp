using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

/// <summary>
/// Stock actual por producto y almacen
/// </summary>
public partial class Inventario
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public int AlmacenId { get; set; }

    public int Cantidad { get; set; }

    public string? Ubicacion { get; set; }

    public DateTime UltimaActualizacion { get; set; }

    public virtual Almacene Almacen { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}

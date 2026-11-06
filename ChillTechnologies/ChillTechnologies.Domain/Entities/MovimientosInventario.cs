using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

/// <summary>
/// Kardex: entradas, salidas, transferencias y ajustes en un solo libro
/// </summary>
public partial class MovimientosInventario
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public int TipoMovimientoId { get; set; }

    public int? AlmacenOrigenId { get; set; }

    public int? AlmacenDestinoId { get; set; }

    public int Cantidad { get; set; }

    public decimal? CostoUnitario { get; set; }

    public string? DocumentoReferencia { get; set; }

    public int? EmpleadoId { get; set; }

    public string? Observacion { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public virtual Almacene? AlmacenDestino { get; set; }

    public virtual Almacene? AlmacenOrigen { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual TiposMovimientoInventario TipoMovimiento { get; set; } = null!;
}

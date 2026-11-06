using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class TiposMovimientoInventario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    /// <summary>
    /// 1 suma stock, -1 resta, 0 traslado entre almacenes
    /// </summary>
    public short Signo { get; set; }

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();
}

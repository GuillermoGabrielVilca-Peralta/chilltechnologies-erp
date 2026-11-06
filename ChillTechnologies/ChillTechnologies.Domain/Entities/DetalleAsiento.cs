using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class DetalleAsiento
{
    public int Id { get; set; }

    public int AsientoId { get; set; }

    public int CuentaId { get; set; }

    public decimal Debe { get; set; }

    public decimal Haber { get; set; }

    public string? Glosa { get; set; }

    public virtual AsientosContable Asiento { get; set; } = null!;

    public virtual PlanCuenta Cuenta { get; set; } = null!;
}

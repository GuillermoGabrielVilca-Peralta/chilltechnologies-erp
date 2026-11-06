using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class PlanCuenta
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string TipoCuenta { get; set; } = null!;

    public int? CuentaPadreId { get; set; }

    public short Nivel { get; set; }

    /// <summary>
    /// Solo las cuentas de ultimo nivel reciben asientos
    /// </summary>
    public bool AceptaMovimiento { get; set; }

    public string Estado { get; set; } = null!;

    public virtual PlanCuenta? CuentaPadre { get; set; }

    public virtual ICollection<DetalleAsiento> DetalleAsientos { get; set; } = new List<DetalleAsiento>();

    public virtual ICollection<PlanCuenta> InverseCuentaPadre { get; set; } = new List<PlanCuenta>();
}

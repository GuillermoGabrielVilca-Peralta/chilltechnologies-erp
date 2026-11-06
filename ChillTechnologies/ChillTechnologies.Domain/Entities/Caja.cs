using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Caja
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? ResponsableEmpleadoId { get; set; }

    public decimal SaldoInicial { get; set; }

    public decimal SaldoActual { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<MovimientosCaja> MovimientosCajas { get; set; } = new List<MovimientosCaja>();

    public virtual Empleado? ResponsableEmpleado { get; set; }
}

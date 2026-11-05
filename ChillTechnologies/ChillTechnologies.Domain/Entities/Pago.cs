using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Pago
{
    public int Id { get; set; }

    public int SuscripcionId { get; set; }

    public int MetodoPagoId { get; set; }

    public decimal MontoSoles { get; set; }

    public DateTime FechaPago { get; set; }

    public string? Referencia { get; set; }

    public string Estado { get; set; } = null!;

    public virtual MetodosPago MetodoPago { get; set; } = null!;

    public virtual Suscripcione Suscripcion { get; set; } = null!;
}

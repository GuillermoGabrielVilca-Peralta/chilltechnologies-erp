using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Suscripcione
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public decimal MontoSoles { get; set; }

    public int MetodoPagoId { get; set; }

    public string Estado { get; set; } = null!;

    public string? ReferenciaPago { get; set; }

    public DateTime FechaRegistro { get; set; }

    public int? EmpresaId { get; set; }

    public bool RenovacionAutomatica { get; set; }

    public int CantidadLicencias { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual MetodosPago MetodoPago { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Usuario? Usuario { get; set; }
}

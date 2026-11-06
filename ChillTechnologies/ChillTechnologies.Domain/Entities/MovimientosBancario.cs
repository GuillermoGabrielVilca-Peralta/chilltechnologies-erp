using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class MovimientosBancario
{
    public int Id { get; set; }

    public int CuentaBancariaId { get; set; }

    public string Tipo { get; set; } = null!;

    public string Concepto { get; set; } = null!;

    public decimal Monto { get; set; }

    public string? Referencia { get; set; }

    public bool Conciliado { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public virtual CuentasBancaria CuentaBancaria { get; set; } = null!;
}

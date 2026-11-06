using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class CuentasBancaria
{
    public int Id { get; set; }

    public string Banco { get; set; } = null!;

    public string NumeroCuenta { get; set; } = null!;

    public string? Cci { get; set; }

    public string TipoCuenta { get; set; } = null!;

    public string Moneda { get; set; } = null!;

    public decimal Saldo { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<MovimientosBancario> MovimientosBancarios { get; set; } = new List<MovimientosBancario>();
}

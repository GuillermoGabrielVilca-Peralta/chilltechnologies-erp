using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Proveedore
{
    public int Id { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public string? ContactoNombre { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public string CondicionPago { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<CuentasPorPagar> CuentasPorPagars { get; set; } = new List<CuentasPorPagar>();

    public virtual ICollection<OrdenesCompra> OrdenesCompras { get; set; } = new List<OrdenesCompra>();
}

using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

/// <summary>
/// Ficha comercial y de facturacion; puede apuntar a una empresa de flota o a un conductor
/// </summary>
public partial class Cliente
{
    public int Id { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string TipoDocumento { get; set; } = null!;

    public string NumeroDocumento { get; set; } = null!;

    public int? EmpresaId { get; set; }

    public int? UsuarioId { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string CondicionPago { get; set; } = null!;

    public decimal LineaCredito { get; set; }

    public int? VendedorId { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Cotizacione> Cotizaciones { get; set; } = new List<Cotizacione>();

    public virtual ICollection<CuentasPorCobrar> CuentasPorCobrars { get; set; } = new List<CuentasPorCobrar>();

    public virtual Empresa? Empresa { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual Usuario? Usuario { get; set; }

    public virtual Empleado? Vendedor { get; set; }
}

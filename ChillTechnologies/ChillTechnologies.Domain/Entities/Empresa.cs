using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

/// <summary>
/// Clientes corporativos: empresas de taxi, delivery o transporte
/// </summary>
public partial class Empresa
{
    public int Id { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Distrito { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? ContactoNombre { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Flota> Flota { get; set; } = new List<Flota>();

    public virtual ICollection<Geocerca> Geocercas { get; set; } = new List<Geocerca>();

    public virtual ICollection<ReglasScoring> ReglasScorings { get; set; } = new List<ReglasScoring>();

    public virtual ICollection<Suscripcione> Suscripciones { get; set; } = new List<Suscripcione>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

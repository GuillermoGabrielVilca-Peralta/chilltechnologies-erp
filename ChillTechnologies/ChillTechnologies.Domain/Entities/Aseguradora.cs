using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Aseguradora
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Ruc { get; set; }

    public string? ContactoNombre { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<Poliza> Polizas { get; set; } = new List<Poliza>();
}

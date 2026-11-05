using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Plane
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal PrecioSoles { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Nivele
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int PuntosMinimos { get; set; }

    public virtual ICollection<PuntosUsuario> PuntosUsuarios { get; set; } = new List<PuntosUsuario>();
}

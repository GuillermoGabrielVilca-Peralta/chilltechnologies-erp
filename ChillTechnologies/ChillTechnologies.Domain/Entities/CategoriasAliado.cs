using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class CategoriasAliado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Aliado> Aliados { get; set; } = new List<Aliado>();
}

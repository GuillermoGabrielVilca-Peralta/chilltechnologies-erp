using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Ambiente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public short Orden { get; set; }

    public bool EsProductivo { get; set; }

    public virtual ICollection<Despliegue> Despliegues { get; set; } = new List<Despliegue>();
}

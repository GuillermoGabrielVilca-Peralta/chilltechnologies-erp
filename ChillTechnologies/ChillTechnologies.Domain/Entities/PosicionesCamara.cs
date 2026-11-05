using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class PosicionesCamara
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Camara> Camaras { get; set; } = new List<Camara>();
}

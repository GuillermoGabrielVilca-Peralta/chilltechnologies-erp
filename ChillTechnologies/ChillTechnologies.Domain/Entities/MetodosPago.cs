using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class MetodosPago
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Suscripcione> Suscripciones { get; set; } = new List<Suscripcione>();
}

using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class TiposMantenimiento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? KmSugerido { get; set; }

    public virtual ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();
}

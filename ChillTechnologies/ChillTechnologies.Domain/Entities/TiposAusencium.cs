using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class TiposAusencium
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Remunerada { get; set; }

    public int? DiasMaximos { get; set; }

    public virtual ICollection<SolicitudesAusencium> SolicitudesAusencia { get; set; } = new List<SolicitudesAusencium>();
}

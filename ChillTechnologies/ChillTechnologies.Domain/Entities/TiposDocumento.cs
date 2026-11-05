using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class TiposDocumento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int DiasAlertaPrevia { get; set; }

    public virtual ICollection<DocumentosVehiculo> DocumentosVehiculos { get; set; } = new List<DocumentosVehiculo>();
}

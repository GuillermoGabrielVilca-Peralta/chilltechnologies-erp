using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class TiposNotificacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Canal { get; set; } = null!;

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();
}

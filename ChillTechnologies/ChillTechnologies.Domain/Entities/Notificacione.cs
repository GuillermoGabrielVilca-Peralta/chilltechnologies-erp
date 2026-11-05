using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Notificacione
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int TipoNotificacionId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Mensaje { get; set; } = null!;

    public bool Leida { get; set; }

    public DateTime FechaEnvio { get; set; }

    public DateTime? FechaLectura { get; set; }

    public virtual TiposNotificacion TipoNotificacion { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class PuntosUsuario
{
    public int UsuarioId { get; set; }

    public int PuntosActuales { get; set; }
    
    public int PuntosHistoricos { get; set; }

    public int NivelId { get; set; }

    public DateTime UltimaActualizacion { get; set; }

    public virtual Nivele Nivel { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}

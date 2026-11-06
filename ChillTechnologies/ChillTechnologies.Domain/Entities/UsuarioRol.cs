using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class UsuarioRol
{
    public int UsuarioSistemaId { get; set; }

    public int RolId { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public virtual RolesSistema Rol { get; set; } = null!;

    public virtual UsuariosSistema UsuarioSistema { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class RolPermiso
{
    public int RolId { get; set; }

    public int PermisoId { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public virtual Permiso Permiso { get; set; } = null!;

    public virtual RolesSistema Rol { get; set; } = null!;
}

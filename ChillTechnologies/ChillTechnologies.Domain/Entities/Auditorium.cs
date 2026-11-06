using System;
using System.Collections.Generic;

namespace ChillTechnologies.Domain.Entities;

public partial class Auditorium
{
    public int Id { get; set; }

    public int? UsuarioSistemaId { get; set; }

    public string Accion { get; set; } = null!;

    public string? TablaAfectada { get; set; }

    public int? RegistroId { get; set; }

    public string? DatosAntes { get; set; }

    public string? DatosDespues { get; set; }

    public string? DireccionIp { get; set; }

    public DateTime FechaAccion { get; set; }

    public virtual UsuariosSistema? UsuarioSistema { get; set; }
}

namespace ChillTechnologies.Application.DTOsRespuesta;

public record UsuarioResponse
{
    public int Id { get; init; }
    public string Nombres { get; init; } = null!;
    public string Apellidos { get; init; } = null!;
    public string NombreCompleto { get; init; } = null!;
    public string Correo { get; init; } = null!;
    public string? Telefono { get; init; }
    public string? FotoPerfil { get; init; }
    public int PlanId { get; init; }
    public string PlanNombre { get; init; } = null!;
    public int TipoConductorId { get; init; }
    public string TipoConductorNombre { get; init; } = null!;
    public int? EmpresaId { get; init; }
    public string? EmpresaRazonSocial { get; init; }
    public string Estado { get; init; } = null!;
    public DateTime? UltimoAcceso { get; init; }
    public DateTime FechaRegistro { get; init; }
}

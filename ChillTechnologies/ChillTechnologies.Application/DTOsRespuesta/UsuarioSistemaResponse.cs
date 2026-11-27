namespace ChillTechnologies.Application.DTOsRespuesta;

public record UsuarioSistemaResponse
{
    public int Id { get; init; }
    public int EmpleadoId { get; init; }
    public string EmpleadoNombre { get; init; } = null!;
    public string Username { get; init; } = null!;
    public string Estado { get; init; } = null!;
    public DateTime? UltimoAcceso { get; init; }
    public DateTime FechaRegistro { get; init; }
    public IEnumerable<string> Roles { get; init; } = [];
}

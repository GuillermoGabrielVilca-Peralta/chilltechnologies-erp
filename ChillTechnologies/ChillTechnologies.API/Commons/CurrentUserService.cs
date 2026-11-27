using System.Security.Claims;
using ChillTechnologies.Application.Interfaces;

namespace ChillTechnologies.API.Commons;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int UsuarioSistemaId
    {
        get
        {
            var id = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(id, out var usuarioId)
                ? usuarioId
                : throw new UnauthorizedAccessException("No se encontro el usuario en el token.");
        }
    }
}

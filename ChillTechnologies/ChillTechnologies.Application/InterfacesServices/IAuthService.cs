using ChillTechnologies.Domain.Entities;

namespace ChillTechnologies.Application.Interfaces;

public interface IAuthService
{
    (string Token, DateTime Expira) GenerateToken(UsuariosSistema usuario, IEnumerable<string> roles);
}

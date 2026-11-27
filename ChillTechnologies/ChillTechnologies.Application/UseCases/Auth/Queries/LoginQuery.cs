using MediatR;
using ChillTechnologies.Application.Interfaces;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Auth.Queries;

public record LoginQuery : IRequest<LoginResponse>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public record LoginResponse
{
    public string Token { get; init; } = null!;
    public DateTime Expira { get; init; }
    public int UsuarioSistemaId { get; init; }
    public string Username { get; init; } = null!;
    public int EmpleadoId { get; init; }
    public IEnumerable<string> Roles { get; init; } = [];
}

internal sealed class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAuthService _authService;

    public LoginQueryHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IAuthService authService)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _authService = authService;
    }

    public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var usuarios = _unitOfWork.Repository<Domain.Entities.UsuariosSistema>();

        var usuario = await usuarios.FirstOrDefaultAsync(u => u.Username == request.Username);
        
        if (usuario is null || !_passwordHasher.Verify(request.Password, usuario.PasswordHash))
            throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");

        if (usuario.Estado != "Activo")
            throw new UnauthorizedAccessException("El usuario no esta activo.");

        var rolIds = (await _unitOfWork.Repository<Domain.Entities.UsuarioRol>()
                .FindAsync(ur => ur.UsuarioSistemaId == usuario.Id))
            .Select(ur => ur.RolId)
            .ToList();

        var roles = (await _unitOfWork.Repository<Domain.Entities.RolesSistema>()
                .FindAsync(r => rolIds.Contains(r.Id) && r.Estado == "Activo"))
            .Select(r => r.Nombre)
            .ToList();

        var (token, expira) = _authService.GenerateToken(usuario, roles);

        usuario.UltimoAcceso = DateTime.Now;
        usuarios.Update(usuario);
        await _unitOfWork.Complete();

        return new LoginResponse
        {
            Token = token,
            Expira = expira,
            UsuarioSistemaId = usuario.Id,
            Username = usuario.Username,
            EmpleadoId = usuario.EmpleadoId,
            Roles = roles
        };
    }
}

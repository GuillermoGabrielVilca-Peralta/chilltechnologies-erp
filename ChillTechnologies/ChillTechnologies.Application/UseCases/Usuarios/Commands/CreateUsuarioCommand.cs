using MediatR;
using ChillTechnologies.Application.Interfaces;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Usuarios.Commands;

public record CreateUsuarioCommand : IRequest<int>
{
    public string Nombres { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Telefono { get; set; }
    public int PlanId { get; set; }
    public int TipoConductorId { get; set; }
}

internal sealed class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUsuarioCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Usuario
        {
            Nombres = request.Nombres,
            Apellidos = request.Apellidos,
            Correo = request.Correo,
            PasswordHash = _passwordHasher.Hash(request.Password),
            Telefono = request.Telefono,
            PlanId = request.PlanId,
            TipoConductorId = request.TipoConductorId,
            Estado = "Activo",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Usuario>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

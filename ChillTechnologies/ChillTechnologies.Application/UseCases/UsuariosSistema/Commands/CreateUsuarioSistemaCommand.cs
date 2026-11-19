using MediatR;
using ChillTechnologies.Application.Interfaces;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UsuariosSistema.Commands;

public record CreateUsuarioSistemaCommand : IRequest<int>
{
    public int EmpleadoId { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

internal sealed class CreateUsuarioSistemaCommandHandler : IRequestHandler<CreateUsuarioSistemaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUsuarioSistemaCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<int> Handle(CreateUsuarioSistemaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.UsuariosSistema
        {
            EmpleadoId = request.EmpleadoId,
            Username = request.Username,
            PasswordHash = _passwordHasher.Hash(request.Password),
            Estado = "Activo",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.UsuariosSistema>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

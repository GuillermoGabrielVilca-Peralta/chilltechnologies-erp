using MediatR;
using ChillTechnologies.Application.Interfaces;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.UsuariosSistema.Commands;

public record CambiarPasswordUsuarioSistemaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Password { get; set; } = null!;
}

internal sealed class CambiarPasswordUsuarioSistemaCommandHandler : IRequestHandler<CambiarPasswordUsuarioSistemaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;

    public CambiarPasswordUsuarioSistemaCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<Unit> Handle(CambiarPasswordUsuarioSistemaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.UsuariosSistema>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.PasswordHash = _passwordHasher.Hash(request.Password);

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

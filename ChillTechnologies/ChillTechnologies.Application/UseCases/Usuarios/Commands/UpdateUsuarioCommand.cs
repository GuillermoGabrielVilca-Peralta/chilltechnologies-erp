using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Usuarios.Commands;

public record UpdateUsuarioCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombres { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? FotoPerfil { get; set; }
    public int PlanId { get; set; }
    public int TipoConductorId { get; set; }
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Usuario>();

        var usuario = await repo.GetByIdAsync(request.Id);

        usuario!.Nombres = request.Nombres;
        usuario.Apellidos = request.Apellidos;
        usuario.Telefono = request.Telefono;
        usuario.FotoPerfil = request.FotoPerfil;
        usuario.PlanId = request.PlanId;
        usuario.TipoConductorId = request.TipoConductorId;
        usuario.Estado = request.Estado;

        repo.Update(usuario);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

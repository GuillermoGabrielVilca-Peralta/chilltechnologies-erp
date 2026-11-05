using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PuntosUsuarios.Commands;

public record UpdatePuntosUsuarioCommand : IRequest<Unit>
{
    public int UsuarioId { get; set; }
    public int PuntosActuales { get; set; }
    public int PuntosHistoricos { get; set; }
    public int NivelId { get; set; }
}

internal sealed class UpdatePuntosUsuarioCommandHandler : IRequestHandler<UpdatePuntosUsuarioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePuntosUsuarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdatePuntosUsuarioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.PuntosUsuario>();

        var puntos = await repo.GetByIdAsync(request.UsuarioId);

        puntos!.PuntosActuales = request.PuntosActuales;
        puntos.PuntosHistoricos = request.PuntosHistoricos;
        puntos.NivelId = request.NivelId;
        puntos.UltimaActualizacion = DateTime.Now;

        repo.Update(puntos);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

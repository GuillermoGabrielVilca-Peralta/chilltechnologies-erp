using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposConductor.Commands;

public record UpdateTipoConductorCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
}

internal sealed class UpdateTipoConductorCommandHandler : IRequestHandler<UpdateTipoConductorCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTipoConductorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTipoConductorCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposConductor>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

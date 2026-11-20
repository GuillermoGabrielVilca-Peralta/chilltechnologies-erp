using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.HistoriasUsuario.Commands;

public record MoverHistoriaSprintCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int? SprintId { get; set; }
}

internal sealed class MoverHistoriaSprintCommandHandler : IRequestHandler<MoverHistoriaSprintCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public MoverHistoriaSprintCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(MoverHistoriaSprintCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.HistoriasUsuario>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.SprintId = request.SprintId;

        if (request.SprintId == null)
            item.Estado = "Backlog";
        else if (item.Estado == "Backlog")
            item.Estado = "Por hacer";

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

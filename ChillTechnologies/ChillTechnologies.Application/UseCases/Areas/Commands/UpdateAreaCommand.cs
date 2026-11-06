using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Areas.Commands;

public record UpdateAreaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public int? AreaPadreId { get; set; }
    //activa o inactiva
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateAreaCommandHandler : IRequestHandler<UpdateAreaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAreaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateAreaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Area>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Descripcion = request.Descripcion;
        item.AreaPadreId = request.AreaPadreId;
        item.Estado = request.Estado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Recepciones.Commands;

public record UpdateRecepcionCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string? NumeroGuia { get; set; }
    public DateOnly FechaRecepcion { get; set; }
    public string Estado { get; set; } = null!;
    public string? Observaciones { get; set; }
}

internal sealed class UpdateRecepcionCommandHandler : IRequestHandler<UpdateRecepcionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRecepcionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateRecepcionCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Recepcione>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.NumeroGuia = request.NumeroGuia;
        item.FechaRecepcion = request.FechaRecepcion;
        item.Estado = request.Estado;
        item.Observaciones = request.Observaciones;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

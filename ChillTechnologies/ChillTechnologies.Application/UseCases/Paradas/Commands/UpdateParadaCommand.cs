using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Paradas.Commands;

public record UpdateParadaCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int? GeocercaId { get; set; }
    public decimal? Latitud { get; set; }
    public decimal? Longitud { get; set; }
    public DateTime? HoraFin { get; set; }
    public int? DuracionMinutos { get; set; }
}

internal sealed class UpdateParadaCommandHandler : IRequestHandler<UpdateParadaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateParadaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateParadaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Parada>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.GeocercaId = request.GeocercaId;
        item.Latitud = request.Latitud;
        item.Longitud = request.Longitud;
        item.HoraFin = request.HoraFin;
        item.DuracionMinutos = request.DuracionMinutos;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

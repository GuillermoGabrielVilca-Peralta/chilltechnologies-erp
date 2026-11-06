using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetalleAsiento.Commands;

public record CreateDetalleAsientoCommand : IRequest<int>
{
    public int AsientoId { get; set; }
    public int CuentaId { get; set; }
    // Partida doble
    public decimal Debe { get; set; }
    public decimal Haber { get; set; }
    public string? Glosa { get; set; }
}

internal sealed class CreateDetalleAsientoCommandHandler : IRequestHandler<CreateDetalleAsientoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDetalleAsientoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateDetalleAsientoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.DetalleAsiento
        {
            AsientoId = request.AsientoId,
            CuentaId = request.CuentaId,
            Debe = request.Debe,
            Haber = request.Haber,
            Glosa = request.Glosa
        };

        await _unitOfWork.Repository<Domain.Entities.DetalleAsiento>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

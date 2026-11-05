using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Paradas.Commands;

public record CreateParadaCommand : IRequest<int>
{
    public int ViajeId { get; set; }
    public int? GeocercaId { get; set; }
    public decimal? Latitud { get; set; }
    public decimal? Longitud { get; set; }
}

internal sealed class CreateParadaCommandHandler : IRequestHandler<CreateParadaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateParadaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateParadaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Parada
        {
            ViajeId = request.ViajeId,
            GeocercaId = request.GeocercaId,
            Latitud = request.Latitud,
            Longitud = request.Longitud,
            HoraInicio = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Parada>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

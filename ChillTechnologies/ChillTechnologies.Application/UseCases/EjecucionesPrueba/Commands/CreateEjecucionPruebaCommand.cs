using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.EjecucionesPrueba.Commands;

public record CreateEjecucionPruebaCommand : IRequest<int>
{
    public int CasoPruebaId { get; set; }
    public int? VersionId { get; set; }
    public int? EmpleadoId { get; set; }
    public string Resultado { get; set; } = null!;
    public string? Observaciones { get; set; }
}

internal sealed class CreateEjecucionPruebaCommandHandler : IRequestHandler<CreateEjecucionPruebaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEjecucionPruebaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateEjecucionPruebaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.EjecucionesPrueba
        {
            CasoPruebaId = request.CasoPruebaId,
            VersionId = request.VersionId,
            EmpleadoId = request.EmpleadoId,
            Resultado = request.Resultado,
            Observaciones = request.Observaciones,
            FechaEjecucion = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.EjecucionesPrueba>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

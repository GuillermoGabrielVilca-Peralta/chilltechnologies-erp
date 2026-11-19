using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TarifasHora.Queries;

public record GetTarifaVigenteQuery(int CargoId, int? ProyectoId) : IRequest<Domain.Entities.TarifasHora>;

internal sealed class GetTarifaVigenteQueryHandler : IRequestHandler<GetTarifaVigenteQuery, Domain.Entities.TarifasHora>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTarifaVigenteQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Domain.Entities.TarifasHora> Handle(GetTarifaVigenteQuery request, CancellationToken cancellationToken)
    {
        var hoy = DateOnly.FromDateTime(DateTime.Now);
        var repo = _unitOfWork.Repository<Domain.Entities.TarifasHora>();

        var vigentes = (await repo.FindAsync(t =>
            t.CargoId == request.CargoId &&
            t.VigenteDesde <= hoy &&
            (t.VigenteHasta == null || t.VigenteHasta >= hoy))).ToList();

        return (vigentes.FirstOrDefault(t => t.ProyectoId == request.ProyectoId)
            ?? vigentes.FirstOrDefault(t => t.ProyectoId == null))!;
    }
}

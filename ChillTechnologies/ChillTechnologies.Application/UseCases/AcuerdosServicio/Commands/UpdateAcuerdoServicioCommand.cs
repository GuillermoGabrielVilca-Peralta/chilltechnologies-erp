using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AcuerdosServicio.Commands;

public record UpdateAcuerdoServicioCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal HorasRespuestaCritica { get; set; }
    public decimal HorasRespuestaAlta { get; set; }
    public decimal HorasRespuestaNormal { get; set; }
    public decimal HorasResolucion { get; set; }
    public decimal DisponibilidadPorcentaje { get; set; }
    public DateOnly? VigenteHasta { get; set; }
}

internal sealed class UpdateAcuerdoServicioCommandHandler : IRequestHandler<UpdateAcuerdoServicioCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAcuerdoServicioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateAcuerdoServicioCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.AcuerdosServicio>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.HorasRespuestaCritica = request.HorasRespuestaCritica;
        item.HorasRespuestaAlta = request.HorasRespuestaAlta;
        item.HorasRespuestaNormal = request.HorasRespuestaNormal;
        item.HorasResolucion = request.HorasResolucion;
        item.DisponibilidadPorcentaje = request.DisponibilidadPorcentaje;
        item.VigenteHasta = request.VigenteHasta;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

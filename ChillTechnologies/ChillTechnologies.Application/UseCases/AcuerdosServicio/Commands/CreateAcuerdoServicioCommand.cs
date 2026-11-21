using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AcuerdosServicio.Commands;

public record CreateAcuerdoServicioCommand : IRequest<int>
{
    public int ContratoId { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal HorasRespuestaCritica { get; set; } = 2;
    public decimal HorasRespuestaAlta { get; set; } = 8;
    public decimal HorasRespuestaNormal { get; set; } = 24;
    public decimal HorasResolucion { get; set; } = 72;
    public decimal DisponibilidadPorcentaje { get; set; } = 99;
    public DateOnly VigenteDesde { get; set; }
}

internal sealed class CreateAcuerdoServicioCommandHandler : IRequestHandler<CreateAcuerdoServicioCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAcuerdoServicioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateAcuerdoServicioCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.AcuerdosServicio
        {
            ContratoId = request.ContratoId,
            Nombre = request.Nombre,
            HorasRespuestaCritica = request.HorasRespuestaCritica,
            HorasRespuestaAlta = request.HorasRespuestaAlta,
            HorasRespuestaNormal = request.HorasRespuestaNormal,
            HorasResolucion = request.HorasResolucion,
            DisponibilidadPorcentaje = request.DisponibilidadPorcentaje,
            VigenteDesde = request.VigenteDesde
        };

        await _unitOfWork.Repository<Domain.Entities.AcuerdosServicio>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

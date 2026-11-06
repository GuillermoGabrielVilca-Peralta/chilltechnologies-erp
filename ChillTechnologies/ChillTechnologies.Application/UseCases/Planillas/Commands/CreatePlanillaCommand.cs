using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Planillas.Commands;

public record CreatePlanillaCommand : IRequest<int>
{
    public int EmpleadoId { get; set; }
    public int Anio { get; set; }
    public int Mes { get; set; }
    public decimal SueldoBasico { get; set; }
    public decimal Bonificaciones { get; set; }
    public decimal Descuentos { get; set; }
}

internal sealed class CreatePlanillaCommandHandler : IRequestHandler<CreatePlanillaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePlanillaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreatePlanillaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Planilla
        {
            EmpleadoId = request.EmpleadoId,
            Anio = request.Anio,
            Mes = request.Mes,
            SueldoBasico = request.SueldoBasico,
            Bonificaciones = request.Bonificaciones,
            Descuentos = request.Descuentos,
            // El neto no lo manda el cliente: se calcula aqui
            NetoPagar = request.SueldoBasico + request.Bonificaciones - request.Descuentos,
            Estado = "Calculada",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Planilla>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

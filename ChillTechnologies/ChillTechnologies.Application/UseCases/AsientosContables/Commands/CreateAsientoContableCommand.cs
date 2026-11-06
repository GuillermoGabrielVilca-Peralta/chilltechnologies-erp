using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.AsientosContables.Commands;

public record CreateAsientoContableCommand : IRequest<int>
{
    public string Numero { get; set; } = null!;
    public DateOnly Fecha { get; set; }
    public string Glosa { get; set; } = null!;
    // apertura,diario,ajuste,cierre
    public string TipoAsiento { get; set; } = "Diario";
    public int? EmpleadoId { get; set; }
}

internal sealed class CreateAsientoContableCommandHandler : IRequestHandler<CreateAsientoContableCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAsientoContableCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateAsientoContableCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.AsientosContable
        {
            Numero = request.Numero,
            Fecha = request.Fecha,
            Glosa = request.Glosa,
            TipoAsiento = request.TipoAsiento,
            //los totales salen de sus lineas al contabilizar
            TotalDebe = 0,
            TotalHaber = 0,
            Estado = "Borrador",
            EmpleadoId = request.EmpleadoId,
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.AsientosContable>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

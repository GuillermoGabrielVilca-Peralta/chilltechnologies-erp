using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cajas.Commands;

public record CreateCajaCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public int? ResponsableEmpleadoId { get; set; }
    public decimal SaldoInicial { get; set; }
}

internal sealed class CreateCajaCommandHandler : IRequestHandler<CreateCajaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCajaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCajaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Caja
        {
            Nombre = request.Nombre,
            ResponsableEmpleadoId = request.ResponsableEmpleadoId,
            SaldoInicial = request.SaldoInicial,
            SaldoActual = request.SaldoInicial,
            Estado = "Abierta",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Caja>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

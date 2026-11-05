using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MovimientosPuntos.Commands;

public record CreateMovimientoPuntoCommand : IRequest<int>
{
    public int UsuarioId { get; set; }
    // Ganado, Canjeado, Ajuste o Expirado
    public string Tipo { get; set; } = null!;
    // Positivo si suma, negativo si resta
    public int Puntos { get; set; }
    public string? Descripcion { get; set; }
    public int? ViajeId { get; set; }
    public int? CanjeId { get; set; }
}

internal sealed class CreateMovimientoPuntoCommandHandler : IRequestHandler<CreateMovimientoPuntoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMovimientoPuntoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateMovimientoPuntoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.MovimientosPunto
        {
            UsuarioId = request.UsuarioId,
            Tipo = request.Tipo,
            Puntos = request.Puntos,
            Descripcion = request.Descripcion,
            ViajeId = request.ViajeId,
            CanjeId = request.CanjeId,
            FechaMovimiento = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.MovimientosPunto>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

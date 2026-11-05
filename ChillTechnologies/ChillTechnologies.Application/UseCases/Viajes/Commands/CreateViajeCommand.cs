using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Viajes.Commands;

public record CreateViajeCommand : IRequest<int>
{
    public int UsuarioId { get; set; }
    public int VehiculoId { get; set; }
}

internal sealed class CreateViajeCommandHandler : IRequestHandler<CreateViajeCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateViajeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateViajeCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Viaje
        {
            UsuarioId = request.UsuarioId,
            VehiculoId = request.VehiculoId,
            FechaInicio = DateTime.Now,
            PuntosGanados = 0,
            Estado = "En Curso"
        };

        await _unitOfWork.Repository<Domain.Entities.Viaje>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

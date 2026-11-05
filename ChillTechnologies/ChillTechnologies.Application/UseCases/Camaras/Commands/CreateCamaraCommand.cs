using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Camaras.Commands;

public record CreateCamaraCommand : IRequest<int>
{
    public int VehiculoId { get; set; }
    public string? Nombre { get; set; }
    public string? DireccionIp { get; set; }
    public int PosicionId { get; set; }
}

internal sealed class CreateCamaraCommandHandler : IRequestHandler<CreateCamaraCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCamaraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCamaraCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Camara
        {
            VehiculoId = request.VehiculoId,
            Nombre = request.Nombre,
            DireccionIp = request.DireccionIp,
            PosicionId = request.PosicionId,
            Estado = "Desconectada",
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Camara>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

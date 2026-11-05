using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ModelosIa.Commands;

public record CreateModeloIaCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public string Version { get; set; } = null!;
    public string Arquitectura { get; set; } = "YOLOv8";
    public decimal? PrecisionPromedio { get; set; }
    public DateOnly? FechaEntrenamiento { get; set; }
    public bool Activo { get; set; }
}

internal sealed class CreateModeloIaCommandHandler : IRequestHandler<CreateModeloIaCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateModeloIaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateModeloIaCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.ModelosIum
        {
            Nombre = request.Nombre,
            Version = request.Version,
            Arquitectura = request.Arquitectura,
            PrecisionPromedio = request.PrecisionPromedio,
            FechaEntrenamiento = request.FechaEntrenamiento,
            Activo = request.Activo,
            FechaRegistro = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.ModelosIum>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

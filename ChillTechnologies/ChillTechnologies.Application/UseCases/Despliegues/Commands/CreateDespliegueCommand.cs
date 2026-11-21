using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Despliegues.Commands;

public record CreateDespliegueCommand : IRequest<int>
{
    public int VersionId { get; set; }
    public int AmbienteId { get; set; }
    public int? ResponsableId { get; set; }
    public string? Observaciones { get; set; }
}

internal sealed class CreateDespliegueCommandHandler : IRequestHandler<CreateDespliegueCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDespliegueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateDespliegueCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Despliegue
        {
            VersionId = request.VersionId,
            AmbienteId = request.AmbienteId,
            ResponsableId = request.ResponsableId,
            Observaciones = request.Observaciones,
            Estado = "En curso",
            FechaDespliegue = DateTime.Now
        };

        await _unitOfWork.Repository<Domain.Entities.Despliegue>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

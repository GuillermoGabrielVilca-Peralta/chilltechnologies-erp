using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Planes.Commands;

public record CreatePlanCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public decimal PrecioSoles { get; set; }
    public string? Descripcion { get; set; }
}

internal sealed class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePlanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Plane
        {
            Nombre = request.Nombre,
            PrecioSoles = request.PrecioSoles,
            Descripcion = request.Descripcion,
        };

        await _unitOfWork.Repository<Domain.Entities.Plane>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

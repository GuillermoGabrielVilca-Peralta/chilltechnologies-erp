using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposProyecto.Commands;

public record CreateTipoProyectoCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string Modalidad { get; set; } = "Precio fijo";
}

internal sealed class CreateTipoProyectoCommandHandler : IRequestHandler<CreateTipoProyectoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTipoProyectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTipoProyectoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.TiposProyecto
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Modalidad = request.Modalidad
        };

        await _unitOfWork.Repository<Domain.Entities.TiposProyecto>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

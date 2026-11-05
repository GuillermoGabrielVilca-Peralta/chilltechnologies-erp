using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposMantenimiento.Commands;

public record CreateTipoMantenimientoCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public int? KmSugerido { get; set; }
}

internal sealed class CreateTipoMantenimientoCommandHandler : IRequestHandler<CreateTipoMantenimientoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTipoMantenimientoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTipoMantenimientoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.TiposMantenimiento
        {
            Nombre = request.Nombre,
            KmSugerido = request.KmSugerido
        };

        await _unitOfWork.Repository<Domain.Entities.TiposMantenimiento>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

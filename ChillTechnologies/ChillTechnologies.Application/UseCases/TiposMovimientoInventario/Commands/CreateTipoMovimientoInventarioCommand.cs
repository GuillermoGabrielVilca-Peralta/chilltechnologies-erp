using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposMovimientoInventario.Commands;

public record CreateTipoMovimientoInventarioCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    //1 suma stock,-1 resta,0 traslado entre almacenes
    public short Signo { get; set; }
}

internal sealed class CreateTipoMovimientoInventarioCommandHandler : IRequestHandler<CreateTipoMovimientoInventarioCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTipoMovimientoInventarioCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTipoMovimientoInventarioCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.TiposMovimientoInventario
        {
            Nombre = request.Nombre,
            Signo = request.Signo
        };

        await _unitOfWork.Repository<Domain.Entities.TiposMovimientoInventario>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

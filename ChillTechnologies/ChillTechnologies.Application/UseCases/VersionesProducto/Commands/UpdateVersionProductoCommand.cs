using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.VersionesProducto.Commands;

public record UpdateVersionProductoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Numero { get; set; } = null!;
    public string? NotasVersion { get; set; }
    public string Estado { get; set; } = null!;
}

internal sealed class UpdateVersionProductoCommandHandler : IRequestHandler<UpdateVersionProductoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVersionProductoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateVersionProductoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.VersionesProducto>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Numero = request.Numero;
        item.NotasVersion = request.NotasVersion;
        item.Estado = request.Estado;
        item.FechaLiberacion = request.Estado == "Liberada"
            ? item.FechaLiberacion ?? DateOnly.FromDateTime(DateTime.Now)
            : item.FechaLiberacion;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

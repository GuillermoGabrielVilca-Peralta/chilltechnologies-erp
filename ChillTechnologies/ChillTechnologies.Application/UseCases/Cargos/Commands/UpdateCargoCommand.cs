using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cargos.Commands;

public record UpdateCargoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Nivel { get; set; } = null!;
}

internal sealed class UpdateCargoCommandHandler : IRequestHandler<UpdateCargoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCargoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCargoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Cargo>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Nivel = request.Nivel;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

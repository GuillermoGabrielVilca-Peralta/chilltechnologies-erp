using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CategoriasProducto.Commands;

public record UpdateCategoriaProductoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
}

internal sealed class UpdateCategoriaProductoCommandHandler : IRequestHandler<UpdateCategoriaProductoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoriaProductoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCategoriaProductoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.CategoriasProducto>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

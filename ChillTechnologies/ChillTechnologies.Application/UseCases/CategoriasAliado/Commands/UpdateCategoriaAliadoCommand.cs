using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CategoriasAliado.Commands;

public record UpdateCategoriaAliadoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
}

internal sealed class UpdateCategoriaAliadoCommandHandler : IRequestHandler<UpdateCategoriaAliadoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoriaAliadoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCategoriaAliadoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.CategoriasAliado>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

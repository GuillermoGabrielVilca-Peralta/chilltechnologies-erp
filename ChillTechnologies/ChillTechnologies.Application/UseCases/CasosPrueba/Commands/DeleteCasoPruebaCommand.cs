using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CasosPrueba.Commands;

public record DeleteCasoPruebaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteCasoPruebaCommandHandler : IRequestHandler<DeleteCasoPruebaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCasoPruebaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCasoPruebaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.CasosPrueba>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

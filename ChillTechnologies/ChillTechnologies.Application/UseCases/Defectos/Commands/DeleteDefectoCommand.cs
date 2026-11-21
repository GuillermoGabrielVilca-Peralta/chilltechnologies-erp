using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Defectos.Commands;

public record DeleteDefectoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteDefectoCommandHandler : IRequestHandler<DeleteDefectoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDefectoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDefectoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Defecto>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

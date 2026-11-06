using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Recepciones.Commands;

public record DeleteRecepcionCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteRecepcionCommandHandler : IRequestHandler<DeleteRecepcionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRecepcionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteRecepcionCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Recepcione>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

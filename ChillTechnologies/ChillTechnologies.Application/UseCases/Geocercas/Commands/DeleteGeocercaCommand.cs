using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Geocercas.Commands;

public record DeleteGeocercaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteGeocercaCommandHandler : IRequestHandler<DeleteGeocercaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGeocercaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteGeocercaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Geocerca>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

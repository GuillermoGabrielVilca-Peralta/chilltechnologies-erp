using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Aseguradoras.Commands;

public record DeleteAseguradoraCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteAseguradoraCommandHandler : IRequestHandler<DeleteAseguradoraCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAseguradoraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteAseguradoraCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Aseguradora>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

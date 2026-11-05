using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ReglasScoring.Commands;

public record DeleteReglaScoringCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteReglaScoringCommandHandler : IRequestHandler<DeleteReglaScoringCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReglaScoringCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteReglaScoringCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.ReglasScoring>();

        var regla = await repo.GetByIdAsync(request.Id);

        repo.Delete(regla!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

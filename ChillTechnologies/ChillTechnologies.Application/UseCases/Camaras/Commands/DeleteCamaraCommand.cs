using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Camaras.Commands;

public record DeleteCamaraCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteCamaraCommandHandler : IRequestHandler<DeleteCamaraCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCamaraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCamaraCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Camara>();

        var camara = await repo.GetByIdAsync(request.Id);

        repo.Delete(camara!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

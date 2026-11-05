using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PosicionesCamara.Commands;

public record DeletePosicionCamaraCommand(int Id) : IRequest<Unit>;

internal sealed class DeletePosicionCamaraCommandHandler : IRequestHandler<DeletePosicionCamaraCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePosicionCamaraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeletePosicionCamaraCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.PosicionesCamara>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

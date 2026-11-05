using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DocumentosVehiculo.Commands;

public record DeleteDocumentoVehiculoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteDocumentoVehiculoCommandHandler : IRequestHandler<DeleteDocumentoVehiculoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDocumentoVehiculoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteDocumentoVehiculoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.DocumentosVehiculo>();

        var documento = await repo.GetByIdAsync(request.Id);

        repo.Delete(documento!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

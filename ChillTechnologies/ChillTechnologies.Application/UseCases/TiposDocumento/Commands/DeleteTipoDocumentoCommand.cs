using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposDocumento.Commands;

public record DeleteTipoDocumentoCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteTipoDocumentoCommandHandler : IRequestHandler<DeleteTipoDocumentoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTipoDocumentoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTipoDocumentoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposDocumento>();

        var tipo = await repo.GetByIdAsync(request.Id);

        repo.Delete(tipo!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

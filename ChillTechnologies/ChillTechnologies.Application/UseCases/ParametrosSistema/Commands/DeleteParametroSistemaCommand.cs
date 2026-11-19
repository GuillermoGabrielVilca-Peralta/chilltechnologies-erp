using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.ParametrosSistema.Commands;

public record DeleteParametroSistemaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteParametroSistemaCommandHandler : IRequestHandler<DeleteParametroSistemaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteParametroSistemaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteParametroSistemaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.ParametrosSistema>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

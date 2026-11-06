using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Asistencias.Commands;

public record DeleteAsistenciaCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteAsistenciaCommandHandler : IRequestHandler<DeleteAsistenciaCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAsistenciaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteAsistenciaCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Asistencia>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

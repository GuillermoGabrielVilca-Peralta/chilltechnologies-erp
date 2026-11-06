using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cotizaciones.Commands;

public record DeleteCotizacionCommand(int Id) : IRequest<Unit>;

internal sealed class DeleteCotizacionCommandHandler : IRequestHandler<DeleteCotizacionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCotizacionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCotizacionCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Cotizacione>();

        var item = await repo.GetByIdAsync(request.Id);

        repo.Delete(item!);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

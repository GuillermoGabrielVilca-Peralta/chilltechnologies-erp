using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.RegistrosHoras.Commands;

public record AprobarRegistroHoraCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public bool Aprobado { get; set; }
}

internal sealed class AprobarRegistroHoraCommandHandler : IRequestHandler<AprobarRegistroHoraCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public AprobarRegistroHoraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AprobarRegistroHoraCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.RegistrosHora>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Aprobado = request.Aprobado;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

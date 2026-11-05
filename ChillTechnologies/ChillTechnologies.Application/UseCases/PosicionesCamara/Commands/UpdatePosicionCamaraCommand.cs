using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PosicionesCamara.Commands;

public record UpdatePosicionCamaraCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
}

internal sealed class UpdatePosicionCamaraCommandHandler : IRequestHandler<UpdatePosicionCamaraCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePosicionCamaraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdatePosicionCamaraCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.PosicionesCamara>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

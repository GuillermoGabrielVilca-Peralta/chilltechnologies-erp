using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Ambientes.Commands;

public record UpdateAmbienteCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public short Orden { get; set; }
    public bool EsProductivo { get; set; }
}

internal sealed class UpdateAmbienteCommandHandler : IRequestHandler<UpdateAmbienteCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAmbienteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateAmbienteCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.Ambiente>();

        var item = await repo.GetByIdAsync(request.Id);

        item!.Nombre = request.Nombre;
        item.Descripcion = request.Descripcion;
        item.Orden = request.Orden;
        item.EsProductivo = request.EsProductivo;

        repo.Update(item);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposDocumento.Commands;

public record UpdateTipoDocumentoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int DiasAlertaPrevia { get; set; }
}

internal sealed class UpdateTipoDocumentoCommandHandler : IRequestHandler<UpdateTipoDocumentoCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTipoDocumentoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTipoDocumentoCommand request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Domain.Entities.TiposDocumento>();

        var tipo = await repo.GetByIdAsync(request.Id);

        tipo!.Nombre = request.Nombre;
        tipo.DiasAlertaPrevia = request.DiasAlertaPrevia;

        repo.Update(tipo);
        await _unitOfWork.Complete();
        return Unit.Value;
    }
}

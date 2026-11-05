using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposDocumento.Commands;

public record CreateTipoDocumentoCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    public int DiasAlertaPrevia { get; set; }
}

internal sealed class CreateTipoDocumentoCommandHandler : IRequestHandler<CreateTipoDocumentoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTipoDocumentoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTipoDocumentoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.TiposDocumento
        {
            Nombre = request.Nombre,
            DiasAlertaPrevia = request.DiasAlertaPrevia
        };

        await _unitOfWork.Repository<Domain.Entities.TiposDocumento>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

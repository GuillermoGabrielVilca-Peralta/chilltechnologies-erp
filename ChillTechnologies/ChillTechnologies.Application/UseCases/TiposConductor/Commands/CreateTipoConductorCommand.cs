using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.TiposConductor.Commands;

public record CreateTipoConductorCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
}

internal sealed class CreateTipoConductorCommandHandler : IRequestHandler<CreateTipoConductorCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTipoConductorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTipoConductorCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.TiposConductor
        {
            Nombre = request.Nombre,
        };

        await _unitOfWork.Repository<Domain.Entities.TiposConductor>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

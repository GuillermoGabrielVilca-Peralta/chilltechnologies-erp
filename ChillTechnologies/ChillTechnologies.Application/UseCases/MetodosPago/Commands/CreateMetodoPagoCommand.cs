using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.MetodosPago.Commands;

public record CreateMetodoPagoCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
}

internal sealed class CreateMetodoPagoCommandHandler : IRequestHandler<CreateMetodoPagoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMetodoPagoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateMetodoPagoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.MetodosPago
        {
            Nombre = request.Nombre,
        };

        await _unitOfWork.Repository<Domain.Entities.MetodosPago>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

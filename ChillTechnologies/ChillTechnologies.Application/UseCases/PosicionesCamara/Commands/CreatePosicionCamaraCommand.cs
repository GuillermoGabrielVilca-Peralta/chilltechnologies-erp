using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.PosicionesCamara.Commands;

public record CreatePosicionCamaraCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
}

internal sealed class CreatePosicionCamaraCommandHandler : IRequestHandler<CreatePosicionCamaraCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePosicionCamaraCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreatePosicionCamaraCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.PosicionesCamara
        {
            Nombre = request.Nombre,
        };

        await _unitOfWork.Repository<Domain.Entities.PosicionesCamara>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

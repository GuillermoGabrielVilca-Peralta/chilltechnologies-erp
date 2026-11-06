using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.Cargos.Commands;

public record CreateCargoCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
    //operativo,supervisor,fefatura,gerencia ydireccion
    public string Nivel { get; set; } = "Operativo";
}

internal sealed class CreateCargoCommandHandler : IRequestHandler<CreateCargoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCargoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCargoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Cargo
        {
            Nombre = request.Nombre,
            Nivel = request.Nivel
        };

        await _unitOfWork.Repository<Domain.Entities.Cargo>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CategoriasAliado.Commands;

public record CreateCategoriaAliadoCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
}

internal sealed class CreateCategoriaAliadoCommandHandler : IRequestHandler<CreateCategoriaAliadoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoriaAliadoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCategoriaAliadoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.CategoriasAliado
        {
            Nombre = request.Nombre,
        };

        await _unitOfWork.Repository<Domain.Entities.CategoriasAliado>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

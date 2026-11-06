using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.CategoriasProducto.Commands;

public record CreateCategoriaProductoCommand : IRequest<int>
{
    public string Nombre { get; set; } = null!;
}

internal sealed class CreateCategoriaProductoCommandHandler : IRequestHandler<CreateCategoriaProductoCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoriaProductoCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCategoriaProductoCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.CategoriasProducto
        {
            Nombre = request.Nombre
        };

        await _unitOfWork.Repository<Domain.Entities.CategoriasProducto>().Insert(data);
        await _unitOfWork.Complete();
        return data.Id;
    }
}

using MediatR;
using ChillTechnologies.Domain.Interfaces;

namespace ChillTechnologies.Application.UseCases.DetallePedido.Queries;

public record GetAllDetallePedidoQuery : IRequest<IEnumerable<Domain.Entities.DetallePedido>>;

internal sealed class GetAllDetallePedidoQueryHandler : IRequestHandler<GetAllDetallePedidoQuery, IEnumerable<Domain.Entities.DetallePedido>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDetallePedidoQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.DetallePedido>> Handle(GetAllDetallePedidoQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Domain.Entities.DetallePedido>().GetAllAsync();
    }
}

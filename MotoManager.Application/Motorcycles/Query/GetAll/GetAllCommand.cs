using MediatR;
using MotoManager.Domain.Entities;

namespace MotoManager.Application.Motorcycles.Query.GetAll
{
    public record GetAllCommand() : IRequest<ICollection<Motorcycle>>;
}

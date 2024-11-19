using MediatR;
using MotoManager.Application.Common.Models;

namespace MotoManager.Application.Drivers.Command.UpdateDriver
{
    public record UpdateDriverCommand(string Identifier, string DocumentId) : IRequest<Results>;
}

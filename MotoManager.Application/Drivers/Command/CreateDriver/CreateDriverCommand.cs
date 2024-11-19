using MediatR;
using MotoManager.Application.Common.Models;

namespace MotoManager.Application.Drivers.Command.CreateDriver
{
    public record CreateDriverCommand(string Name,
        string Ein,
        string DriverLicense,
        string DriverLicenseType,
        DateTime BornDate,
        string Identifier,
        string? DocumentId) : IRequest<Results>;
}

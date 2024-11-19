using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoManager.Application.Common.Models;
using MotoManager.Domain.Entities;
using MotoManager.Infraestructure.Data;

namespace MotoManager.Application.Drivers.Command.CreateDriver
{
    public class CreateDriverCommandHandler(IMotorcycleManagerContext context) : IRequestHandler<CreateDriverCommand, Results>
    {
        public async Task<Results> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var driverCheck = await context.Drivers.FirstOrDefaultAsync(p => p.Ein == request.Ein && p.DriverLicense == request.DriverLicense);
                if (driverCheck != null)
                {
                    return Results.Fail(false, "400", "Entregador já existente");
                }


                Driver driverToInser = new Driver()
                {
                    Name = request.Name,
                    DriverLicense = request.DriverLicense,
                    Ein = request.Ein,
                    BornDate = request.BornDate,
                    DriverLicenseType = request.DriverLicenseType,
                    CreatedAt = DateTime.UtcNow,
                    DocumentID = request.DocumentId == string.Empty ? null : request.DocumentId,
                    Identifier = request.Identifier,
                };

                await context.Drivers.AddAsync(driverToInser);
                await context.SaveChangesAsync(cancellationToken);
                return Results.Ok(true, "Entregador criado com sucesso", [driverToInser]);

            }
            catch (Exception ex)
            {

                return Results.Fail(false, "400", ex.Message);
            }


        }
    }
}

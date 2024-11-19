using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoManager.Application.Common.Models;
using MotoManager.Infraestructure.Data;

namespace MotoManager.Application.Drivers.Command.UpdateDriver
{
    public class UpdateDriverCommandHandler(IMotorcycleManagerContext context) : IRequestHandler<UpdateDriverCommand, Results>
    {
        public async Task<Results> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var driver = await context.Drivers.FirstOrDefaultAsync(p => p.Identifier == request.Identifier);
                if (driver == null)
                {
                    return Results.Fail(false, "404", "Entregador não encontrado");
                }

                driver.DocumentID = request.DocumentId;

                context.Drivers.Update(driver);
                var ret = await context.SaveChangesAsync(cancellationToken);
                return Results.Ok(true, "Entregador criado com sucesso", [driver]);
            }
            catch (Exception ex)
            {
                return Results.Fail(false, "400", ex.Message);
            }
        }
    }
}

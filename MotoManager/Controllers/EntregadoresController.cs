using MediatR;
using Microsoft.AspNetCore.Mvc;
using MotoManager.Application.Drivers.Command.CreateDriver;
using MotoManager.Application.Drivers.Command.UpdateDriver;
using MotoManager.Application.Services.DriverService;
using MotoManager.Dtos;

namespace MotoManager.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EntregadoresController(IGoogleDriveService _googleDriveService, ISender sender) : ControllerBase
    {
        [HttpPost("{id}/cnh")]
        public async Task<IResult> UploadToGoogleDrive(string id, [FromBody] string base64Image)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(base64Image))
                    return Results.BadRequest(new { message = "The image data cannot be empty." });

                var fileId = await UploadImageToGDrive(base64Image);

                var command = new UpdateDriverCommand(id, fileId);
                var ret = await sender.Send(command);
                if (ret.Success)
                    return Results.Ok(ret.Returns.FirstOrDefault());
                return Results.BadRequest();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = "Error uploading image", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IResult> Create(CreateDriverDto driver)
        {
            try
            {
                string imageId = string.Empty;

                if (!string.IsNullOrEmpty(driver.Imagem_Cnh))
                    imageId = await UploadImageToGDrive(driver.Imagem_Cnh);

                var command = new CreateDriverCommand(driver.Nome, driver.Cnpj, driver.Numero_Cnh, driver.Tipo_Cnh, driver.Data_Nascimento, driver.Identificador, imageId);
                var ret = await sender.Send(command);

                if (ret.Success)
                {
                    return Results.Created("200", ret.Returns);
                }

                return Results.BadRequest(new Dictionary<string, string> { ["mensagem"] = ret.Message });
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }

        }

        private async Task<string> UploadImageToGDrive(string base64Image)
        {

            if (string.IsNullOrWhiteSpace(base64Image))
                return string.Empty;

            var fileId = await _googleDriveService.UploadBase64ImageAsync(base64Image, Guid.NewGuid().ToString());
            return fileId;

        }
    }
}
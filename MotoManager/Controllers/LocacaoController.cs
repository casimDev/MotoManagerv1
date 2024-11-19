using Microsoft.AspNetCore.Mvc;
using MotoManager.Dtos;

namespace MotoManager.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LocacaoController : ControllerBase
    {
        [HttpPost]
        public async Task<IResult> Create()
        {
            return Results.Created();
        }

        [HttpGet("{id}")]
        public async Task<LocacaoMotocicletaDto> GetById(Guid id)
        {
            return new LocacaoMotocicletaDto();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(Guid id)
        {
            return Results.Ok();
        }

        [HttpPut("{id}")]
        public async Task<IResult> Update(Guid id)
        {
            return Results.Ok();
        }

    }
}

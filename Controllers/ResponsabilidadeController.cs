using Loja.Data;
using Loja.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loja.Controllers
{
    public class ResponsabilidadeController : ControllerBase
    {
        
        
        
        [HttpGet("e1/responsabilidade")]
        public async Task<IActionResult> GetAsync([FromServices] EmpresaDataContext context)
        {
            var resp = await context.Responsabilidades.ToListAsync();
            await context.SaveChangesAsync();

            return Ok(resp);
        }

        [HttpGet("e1/responsabilidade/id")]
        public async Task<IActionResult> GetByIdAsync([FromServices] EmpresaDataContext context, [FromRoute] int id)
        {
            var resp = await  context.Responsabilidades.FirstOrDefaultAsync(x => x.RespId == id);
            return Ok(resp);
        }

        [HttpPost("e1/responsabilidade")]
        public async Task<IActionResult> PostAsync([FromServices] EmpresaDataContext context, [FromBody] Responsabilidade model)
        {

            

            await context.Responsabilidades.AddAsync(model);
            await context.SaveChangesAsync();

            return Created($"d1/funcionario{model.RespId}", model);
        }

        [HttpPut("e1/responsabilidade")]
        public async Task<IActionResult> PutAsync([FromServices] EmpresaDataContext context, [FromRoute] int id, [FromBody] Responsabilidade model)
        {
            var resp = await context.Responsabilidades.FirstOrDefaultAsync(x => x.RespId == id);

            if (resp == null)
                return NotFound();

            resp.Ativo = model.Ativo;
            resp.Name = model.Name;

            context.Responsabilidades.Update(resp);
            await context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpDelete("e1/responsabilidade")]
        public async Task<IActionResult> DeleteAsync([FromServices] EmpresaDataContext context, [FromRoute] int id, [FromBody] Responsabilidade model)
        {
            var resp = await context.Responsabilidades.FirstOrDefaultAsync(x => x.RespId == id);

            if (resp == null)
                return NotFound();

            context.Responsabilidades.Remove(resp);
            await context.SaveChangesAsync();

            return Ok(resp);
        }

    }
}

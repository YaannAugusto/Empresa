using Loja.Data;
using Loja.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loja.Controllers
{
    public class EmpresController : ControllerBase
    {

        [HttpGet("c1/Empresa")]
        public async Task<IActionResult> GetAsync([FromServices] EmpresaDataContext context)
        {
            var empresa = await context.Empresas.ToListAsync();
            return Ok(empresa);
        }

        [HttpGet("c1/Empresa/{id:int}")] //localhost:PORT/v1/categories
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] EmpresaDataContext context)
        {
            var empresa = await context.Empresas.FirstOrDefaultAsync(x => x.EmployeeId == id);

          
            return Ok(empresa);

        }

        [HttpPost("c1/Empresa")]
        public async Task<IActionResult> PostAsync([FromBody] Empres model, [FromServices] EmpresaDataContext context)
        {
            var empresa = new Empres
            {
                Cep = model.Cep,
                Company = model.Company
            };

            await context.Empresas.AddAsync(empresa);
            context.SaveChanges();

            return Created($"v1/empresas{empresa.EmployeeId}", empresa);
        }


        [HttpPut("c1/Empresa")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] Empres model, [FromServices] EmpresaDataContext context)
        {
            var empresa = await context.Empresas.FirstOrDefaultAsync(x => x.EmployeeId == id);

            if (empresa == null)
                return NotFound();

            empresa.Cep = model.Cep;
            empresa.Company = model.Company;


            context.Empresas.Update(empresa);
            await context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpDelete("c1/Empresa")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id, [FromBody] Empres model, [FromServices] EmpresaDataContext context)
        {
            var empresa = await context.Empresas.FirstOrDefaultAsync(x => x.EmployeeId == id);

            if (empresa == null)
                return NotFound();

            context.Empresas.Remove(empresa);
            context.SaveChanges();

            return Ok(empresa);
        }
    }
}

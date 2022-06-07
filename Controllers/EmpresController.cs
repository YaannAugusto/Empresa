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
            try
            {
                var empresa = await context.Empresas.ToListAsync();
                return Ok(empresa);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05XE8 - Não foi possivel alterar a categoria!");

            }

            catch (Exception ex)
            {
                return StatusCode(500, "05XE11 - Falha interna no servidor!");

            }
        }

        [HttpGet("c1/Empresa/id")] 
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] EmpresaDataContext context)
        {
            var empresa = await context.Empresas.FirstOrDefaultAsync(x => x.EmployeeId == id);

          
            return Ok(empresa);

        }

        [HttpPost("c1/Empresa")]
        public async Task<IActionResult> PostAsync([FromBody] Empres model, [FromServices] EmpresaDataContext context)
        {
            //Nesse caso, vc já está recebendo a entidade do banco via Body do HTTP, porém não é o correto.
            await context.Empresas.AddAsync(model);
            await context.SaveChangesAsync();

            return Created($"v1/empresas{model.EmployeeId}", model);
        }


        [HttpPut($"c1/Empresa/")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] Empres model, [FromServices] EmpresaDataContext context)
        {
            var empresa = await context.Empresas.FirstOrDefaultAsync(x => x.EmployeeId == id);

            if (empresa == null)
                return NotFound();

            empresa.Cep = model.Cep;
            empresa.Company = model.Company;
            empresa.Funcionarios = model.Funcionarios;


            context.Empresas.Update(empresa);
            await context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpDelete($"c1/Empresa")]
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

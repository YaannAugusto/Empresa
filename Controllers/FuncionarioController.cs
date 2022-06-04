using Loja.Data;
using Loja.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loja.Controllers
{
    public class FuncionarioController : ControllerBase
    {
        /*

        [HttpGet("d1/funcionario")]
        public async Task<IActionResult> GetAsync([FromServices] EmpresaDataContext context)
        {
            var funcionario = await context.Funcionarios.ToListAsync();
            return Ok(funcionario);
        }

        [HttpGet("d1/funcionario")]
        public  IActionResult GetById ([FromRoute] int id, [FromServices] EmpresaDataContext context)
        { 
                
            var funcionario =  context.Funcionarios.FirstOrDefault(x => x.Id == id);
            return Ok(funcionario);
        }

        [HttpPost("d1/funcionario")]
        public async Task<IActionResult> PostAsync([FromBody] Funcionario model, [FromServices] EmpresaDataContext context)
        {
            var funcionario = new Funcionario
            {
                Id = model.Id,
                Name = model.Name,
                Cpf = model.Cpf,
                Func = model.Func
            };

            await context.Funcionarios.AddAsync(funcionario);
            context.SaveChanges();

            return Created($"d1/funcionario{funcionario.Id}", funcionario);
        }

        [HttpPut("d1/funcionario")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] Funcionario model, [FromServices] EmpresaDataContext context)
        {
            var funcionario =  context.Funcionarios.FirstOrDefault(x => x.Id == id);

            if(funcionario == null)
                return NotFound();

            funcionario.Id = model.Id;
            funcionario.Name = model.Name;
            funcionario.Cpf = model.Cpf;
            funcionario.Func = model.Func;

             context.Funcionarios.Update(funcionario);
            await context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpDelete("d1/funcionario")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id, [FromServices] EmpresaDataContext context)
        {
            var funcionario =  await context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);

            if (funcionario == null)
                return NotFound();


            context.Funcionarios.Remove(funcionario);
            await context.SaveChangesAsync();


            return Ok(funcionario);

        
        }
     */
    }
}

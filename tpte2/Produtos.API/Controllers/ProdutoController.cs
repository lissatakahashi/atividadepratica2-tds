using Microsoft.AspNetCore.Mvc;
using Produtos.API.Models;
using Produtos.Data;

namespace Produtos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Get(
            [FromServices] AppDbContext context)
        {
            return Ok(context.Produtos!.ToList());
        }

        [HttpGet("/{id:int}")]
        public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var produtoModel = context.Produtos!.FirstOrDefault(x => x.ProdutoId == id);
            if (produtoModel == null) {
                return NotFound();
            }
            return Ok(produtoModel);
        }

        [HttpPost("/")]
        public IActionResult Post([FromBody] ProdutoModel produtoModel, [FromServices] AppDbContext context)
        {
            context.Produtos!.Add(produtoModel);
            context.SaveChanges();
            return Created($"/{produtoModel.ProdutoId}", produtoModel);
        }

        [HttpPut("/")]
        public IActionResult Put([FromRoute] int id, [FromBody] ProdutoModel produtoModel, [FromServices] AppDbContext context)
        {
            var model = context.Produtos!.FirstOrDefault(x => x.ProdutoId == id);
            if (model == null) {
                return NotFound();
            }

            model.Nome = produtoModel.Nome;
            model.Preco = produtoModel.Preco;
            model.Quantidade = produtoModel.Quantidade;

            context.Produtos!.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("/")]
        public IActionResult Delete([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var model = context.Produtos!.FirstOrDefault(x => x.ProdutoId == id);
            if (model == null) {
                return NotFound();
            }

            context.Produtos!.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}
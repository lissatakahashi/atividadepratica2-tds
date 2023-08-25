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
        public List<ProdutoModel> Get(
            [FromServices] AppDbContext context)
        {
            return context.Produtos!.ToList();
        }

        [HttpGet("/{id:int}")]
        public ProdutoModel GetById([FromRoute] int id, [FromServices] AppDbContext context)
        {
            return context.Produtos!.FirstOrDefault(x => x.ProdutoId == id);
        }

        [HttpPost("/")]
        public ProdutoModel Post([FromBody] ProdutoModel produtoModel, [FromServices] AppDbContext context)
        {
            context.Produtos!.Add(produtoModel);
            context.SaveChanges();
            return produtoModel;
        }

        [HttpPut("/")]
        public ProdutoModel Put([FromRoute] int id, [FromBody] ProdutoModel produtoModel, [FromServices] AppDbContext context)
        {
            var model = context.Produtos!.FirstOrDefault(x => x.ProdutoId == id);
            if (model == null) {
                return produtoModel;
            }

            model.Nome = produtoModel.Nome;
            model.Preco = produtoModel.Preco;
            model.Quantidade = produtoModel.Quantidade;

            context.Produtos!.Update(model);
            context.SaveChanges();
            return model;
        }

        [HttpDelete("/")]
        public ProdutoModel Delete([FromRoute] int id, [FromServices] AppDbContext context)
        {
            
        }
    }
}
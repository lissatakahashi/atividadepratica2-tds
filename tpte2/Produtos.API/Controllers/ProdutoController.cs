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

        [HttpPost("/")]
        public ProdutoModel Post([FromBody] ProdutoModel produtoModel, [FromServices] AppDbContext context)
        {
            context.Produtos!.Add(produtoModel);
            context.SaveChanges();
            return produtoModel;
        }
    }
}
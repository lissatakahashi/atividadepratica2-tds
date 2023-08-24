using System.ComponentModel.DataAnnotations;

namespace Produtos.API.Models
{
    public class ProdutoModel
    {
        [Key]
        public int? ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }

        public ProdutoModel(int? produtoId, string nome, decimal preco, int quantidade)
        {
            ProdutoId = produtoId;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }
    }
}
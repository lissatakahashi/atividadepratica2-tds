using Produtos.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Produtos.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProdutoModel>? Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=tds.db;Cache=Shared");
    }
}
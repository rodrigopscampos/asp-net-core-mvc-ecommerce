using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AspNetCoreMvcEcommerce.Data
{
    public class AspNetCoreMvcEcommerceContext : IdentityDbContext
    {
        static Random _random = new Random();
        const string ImageFolder = "img";

        int _produtoId;

        public AspNetCoreMvcEcommerceContext(DbContextOptions<AspNetCoreMvcEcommerceContext> options)
            : base(options)
        {
            
        }

        public AspNetCoreMvcEcommerceContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            

            builder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Descricao = "Smartphones" },
                new Categoria { Id = 2, Descricao = "Notebooks" },
                new Categoria { Id = 3, Descricao = "TVs" },
                new Categoria { Id = 4, Descricao = "Video Games" }
                );

            //builder.Entity<Produto>().HasData(GerarProdutos("Smartphones", 1, 5, 200, 2000));


            base.OnModelCreating(builder);
        }

        private IEnumerable<Produto> GerarProdutos(string categoriaDescricao, int categoriaId, int qtdade, int precoMinimo, int precoMaximo)
        {
            return Enumerable.Range(0, qtdade)
                .Select(i => new Produto
                {
                    Id = ++_produtoId,
                    Nome = $"{categoriaDescricao} - Produto {i}",
                    Descricao = $"Produto {categoriaDescricao} - Produto {i} ...",
                    Preco = _random.Next(precoMinimo * 100, precoMaximo * 100) / 100,
                    Imagem = ImageFolder + "/" + categoriaDescricao + "_" + i + ".jpg",
                    CategoriaId = categoriaId
                });
        }

        /*
        public AspNetCoreMvcEcommerceContext()
           : base("AspNetMvcEcommerce")
        {
        }

        public static AspNetCoreMvcEcommerceContext Create()
        {
            return new AspNetCoreMvcEcommerceContext();
        }
        */

        public virtual DbSet<Ordem> Ordens { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
    }
}

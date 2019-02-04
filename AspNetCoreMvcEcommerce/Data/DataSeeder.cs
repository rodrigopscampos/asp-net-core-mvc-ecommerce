using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcEcommerce.Data
{
    public class DataSeeder
    {
        static int _produtoId;
        static Random _random = new Random();
        const string ImageFolder = "img";

        public static void SeedCountries(AspNetCoreMvcEcommerceContext context)
        {
            if (!context.Categorias.Any())
            {
                context.Categorias.AddRange(
                  GerarCategoriaComProdutos("Smartphones", 5, 200, 5000),
                  GerarCategoriaComProdutos("Notebooks", 10, 800, 10000),
                  GerarCategoriaComProdutos("TVs", 10, 400, 1000),
                  GerarCategoriaComProdutos("Video Games", 3, 500, 2000)
                  );

                //context.Categorias.AddRange(
                //    new Categoria { Id = 1, Descricao = "Smartphones" },
                //    new Categoria { Id = 2, Descricao = "Notebooks" },
                //    new Categoria { Id = 3, Descricao = "TVs" },
                //    new Categoria { Id = 4, Descricao = "Video Games" }
                //);

                context.SaveChanges();

                //context.Produtos.AddRange(GerarProdutos("Smartphones", 1, 5, 200, 2000));
                //context.Produtos.AddRange(GerarProdutos("Notebooks", 2, 5, 200, 2000));
                //context.Produtos.AddRange(GerarProdutos("TVs", 3, 5, 200, 2000));
                //context.Produtos.AddRange(GerarProdutos("Video Games", 4, 5, 200, 2000));
            }
        }

        private static Categoria GerarCategoriaComProdutos(string descricao, int qtdadeProdutos, int precoMinimo, int precoMaximo)
        {
            var produtos = Enumerable.Range(0, qtdadeProdutos)
                .Select(i => new Produto
                {
                    Nome = $"{descricao} - Produto {i}",
                    Descricao = $"Produto {descricao} - Produto {i} ...",
                    Preco = _random.Next(precoMinimo * 100, precoMaximo * 100) / 100,
                    Imagem = ImageFolder + "/" + descricao + "_" + i + ".jpg"
                })
                .ToArray();

            return new Categoria
            {
                Descricao = descricao,
                Produtos = produtos
            };
        }

        private static IEnumerable<Produto> GerarProdutos(string categoriaDescricao, int categoriaId, int qtdade, int precoMinimo, int precoMaximo)
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
    }
}

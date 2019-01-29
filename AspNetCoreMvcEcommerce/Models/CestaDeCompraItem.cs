namespace AspNetCoreMvcEcommerce.Models
{

    public class CestaDeCompraItem
    {
        public int ProdutoId { get; set; }
        public string NomeDoProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }

        public decimal PrecoTotal => PrecoUnitario * Quantidade;
    }
}
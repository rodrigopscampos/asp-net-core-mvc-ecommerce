namespace AspNetCoreMvcEcommerce
{
    public partial class OrdemItem
    {
        public int Id { get; set; }

        public int OrdemId { get; set; }
        public Ordem Ordem { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}
using System.Collections.Generic;

namespace AspNetCoreMvcEcommerce
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
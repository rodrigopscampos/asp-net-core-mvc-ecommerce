using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AspNetCoreMvcEcommerce
{
    public partial class Ordem
    {
        public int Id { get; set; }

        public DateTime DataDeCriacao { get; set; }
        public DateTime DataDeEntrega { get; set; }

        public string ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int OrdemItemsId { get; set; }
        public virtual ICollection<OrdemItem> OrdemItems { get; set; }

        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string CcNumero { get; set; }
         
        public DateTime? CcValidade { get; set; }

        [NotMapped]
        public decimal PrecoTotal => OrdemItems?.Sum(i => i.Preco) ?? 0;
    }
}
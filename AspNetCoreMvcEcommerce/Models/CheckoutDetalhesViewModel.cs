using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvcEcommerce.Models
{
    public class CheckoutDetalhesViewModel
    {
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Estado é requerido")]
        public string Estado { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Endereço é requerido")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "CEP é requerido")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Número do Cartão de Crédito é requerido")]
        [Display(Name = "Número")]
        public string CcNumero { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Validade do cartão é requerida")]
        [Display(Name = "Validade")]
        public DateTime CcValidade { get; set; } = DateTime.Today.AddYears(1);
    }
}